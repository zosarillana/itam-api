using ITAM_API.Data;
using ITAM_API.Model.Operations;
using ITAM_DB.Controllers.Itot;
using ITAM_DB.Dto;
using ITAM_DB.Dto.Cards;
using ITAM_DB.Model.Cards;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITAM_DB.Controllers.Cards
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : Controller
    {
        private readonly ItotContext _context; // Your DbContext       
        public CardController(ItotContext context, ILogger<ImportItotController> logger)
        {
            _context = context;
        }
        // GET: /Cards
        [HttpPost]
        public async Task<ActionResult<List<Pc_CardDto>>> CreatePcCard([FromBody] Pc_CardDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Pc_CardDto is required");
            }

            // Initialize lists to hold parsed integers
            var pcIds = new List<int>();
            var peripheralIds = new List<int>();

            // Attempt to convert pc_id and peripheral_id to lists of integers for lookup
            try
            {
                // Split and parse pc_id
                if (!string.IsNullOrWhiteSpace(dto.pc_id))
                {
                    pcIds = dto.pc_id.Split(',')
                                     .Select(id => int.TryParse(id.Trim(), out var result) ? result : (int?)null)
                                     .Where(id => id.HasValue)
                                     .Select(id => id.Value)
                                     .ToList();
                }
                else
                {
                    return BadRequest("pc_id cannot be empty.");
                }

                // Split and parse peripheral_id
                if (!string.IsNullOrWhiteSpace(dto.peripheral_id))
                {
                    peripheralIds = dto.peripheral_id.Split(',')
                                                     .Select(id => int.TryParse(id.Trim(), out var result) ? result : (int?)null)
                                                     .Where(id => id.HasValue)
                                                     .Select(id => id.Value)
                                                     .ToList();
                }
                else
                {
                    return BadRequest("peripheral_id cannot be empty.");
                }
            }
            catch (Exception ex)
            {
                // Catch any other unexpected exceptions
                return BadRequest("Error parsing pc_id or peripheral_id: " + ex.Message);
            }

            var pcCard = new Pc_Card
            {
                firstName = dto.firstName,
                lastName = dto.lastName,
                emp_id = dto.emp_id,
                contact_no = dto.contact_no,
                dept_name = dto.dept_name,
                company_name = dto.company_name,
                location = dto.location,
                date_assigned = dto.date_assigned,
                pc_id = dto.pc_id, // Keep as string for database insertion
                peripheral_id = dto.peripheral_id // Keep as string for database insertion
            };

            try
            {
                // Add the new Pc_Card to the context
                _context.Pc_Cards.Add(pcCard);
                await _context.SaveChangesAsync();

                // Now update the assigned fields in Itot_Pcs and Itot_Peripherals
                var assignedValue = "Assigned to " + dto.firstName + " " + dto.lastName;

                // Update Itot_Pcs for each pcId if it exists
                foreach (var pcId in pcIds)
                {
                    var itotPc = await _context.Itot_Pcs.FindAsync(pcId);
                    if (itotPc != null)
                    {
                        itotPc.assigned = assignedValue; // Assuming there's an 'assigned' property
                    }
                }

                // Update Itot_Peripherals for each peripheralId if it exists
                foreach (var peripheralId in peripheralIds)
                {
                    var itotPeripheral = await _context.Itot_Peripherals.FindAsync(peripheralId);
                    if (itotPeripheral != null)
                    {
                        itotPeripheral.assigned = assignedValue; // Assuming there's an 'assigned' property
                    }
                }

                // Save changes for Itot_Pcs and Itot_Peripherals
                await _context.SaveChangesAsync();

                // Return the updated list of Pc_Cards
                return Ok(await _context.Pc_Cards.ToListAsync());
            }
            catch (DbUpdateException ex)
            {
                // Log the exception (consider using a logging framework)
                return BadRequest("Error saving the Pc_Card: " + ex.InnerException?.Message ?? ex.Message);
            }
        }


        [HttpGet]
        public async Task<ActionResult<List<Pc_CardAllDataDto>>> GetPcCard()
        {
            // Fetch all necessary data from the database
            var pc_cards = await _context.Pc_Cards.ToListAsync();
            var pcsData = await _context.Itot_Pcs.ToListAsync();
            var peripheralsData = await _context.Itot_Peripherals.ToListAsync();

            // Map Pc_Cards to DTOs
            var result = pc_cards
                .Select(pcc =>
                {
                    // Split the comma-separated pc_ids and peripheral_ids
                    var pcIds = pcc.pc_id?.Split(',').Select(id => int.TryParse(id, out var result) ? result : (int?)null).Where(id => id.HasValue).Select(id => id.Value).ToList();
                    var peripheralIds = pcc.peripheral_id?.Split(',').Select(id => int.TryParse(id, out var result) ? result : (int?)null).Where(id => id.HasValue).Select(id => id.Value).ToList();

                    return new Pc_CardAllDataDto
                    {
                        id = pcc.id,
                        firstName = pcc.firstName,
                        lastName = pcc.lastName,
                        emp_id = pcc.emp_id,
                        contact_no = pcc.contact_no,
                        dept_name = pcc.dept_name,
                        company_name = pcc.company_name,
                        location = pcc.location,
                        date_assigned = pcc.date_assigned,
                        date_created = pcc.date_created,
                        date_updated = pcc.date_updated,

                        // List of Pcs (filtered by pc_id)
                        Pcs = pcsData
                            .Where(pc => pcIds != null && pcIds.Contains(pc.id)) // Check if pc.id is in the list of pcIds
                            .Select(pc => new Itot_PcDto
                            {
                                id = pc.id,
                                asset_barcode = pc.asset_barcode,
                                date_acquired = pc.date_acquired,
                                pc_type = pc.pc_type,
                                brand = pc.brand,
                                model = pc.model,
                                processor = pc.processor,
                                ram = pc.ram,
                                storage_capacity = pc.storage_capacity,
                                storage_type = pc.storage_type,
                                operating_system = pc.operating_system,
                                graphics = pc.graphics,
                                size = pc.size,
                                color = pc.color,
                                li_description = pc.li_description,
                                serial_no = pc.serial_no,
                                assigned = pc.assigned,
                                status = pc.status,
                                date_created = pc.date_created,
                                date_updated = pc.date_updated
                            })
                            .ToList(),

                        // List of Peripherals (filtered by peripheral_id)
                        Peripherals = peripheralsData
                            .Where(peripheral => peripheralIds != null && peripheralIds.Contains(peripheral.id)) // Check if peripheral.id is in the list of peripheralIds
                            .Select(peripheral => new Itot_PeripheralDto
                            {
                                id = peripheral.id,
                                asset_barcode = peripheral.asset_barcode,
                                date_acquired = peripheral.date_acquired,
                                brand = peripheral.brand,
                                model = peripheral.model,
                                peripheral_type = peripheral.peripheral_type,
                                size = peripheral.size,
                                color = peripheral.color,
                                li_description = peripheral.li_description,
                                serial_no = peripheral.serial_no,
                                assigned = peripheral.assigned,
                                status = peripheral.status,
                                date_created = peripheral.date_created,
                                date_updated = peripheral.date_updated
                            })
                            .ToList(),
                    };
                })
                .ToList();

            return Ok(result);
        }
    }
}
