using ITAM_API.Data;
using ITAM_API.Data.Itot;
using ITAM_API.Model.Operations;
using ITAM_DB.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITAM_DB.Controllers.Itot
{
    [ApiController]
    [Route("[controller]")]
    public class ItotController : ControllerBase
    {
        private readonly ItotContext _context; // Your DbContext
        private readonly ILogger<ImportItotController> _logger;
        public ItotController(ItotContext context, ILogger<ImportItotController> logger)
        {
            _context = context;
            _logger = logger;
        }
        //itot pcs
        [HttpGet("pc")]
        public async Task<ActionResult<IEnumerable<Itot_Pc>>> GetAllPcs()
        {
            var items = await _context.Itot_Pcs.ToListAsync(); // Use your DbSet for Itot_Pc
            return Ok(items); // Return 200 OK with the list of items
        }

        [HttpGet("pc/{id}")]
        public async Task<ActionResult<Itot_Pc>> GetById(int id)
        {
            var item = await _context.Itot_Pcs.FindAsync(id); // Find the item by ID

            if (item == null)
            {
                return NotFound(); // Return 404 Not Found if the item doesn't exist
            }

            return Ok(item); // Return 200 OK with the item
        }

        [HttpDelete("pc/delete/{id}")]
        public async Task<ActionResult> DeletePc(int id)
        {
            // Find the peripheral by its ID
            var pc = await _context.Itot_Pcs.FindAsync(id);

            // Check if the peripheral exists
            if (pc == null)
            {
                return NotFound(new { message = "Pc not found." });  // Return JSON response
            }

            // Remove the peripheral from the database
            _context.Itot_Pcs.Remove(pc);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Pc deleted successfully." });  // Return JSON response
        }

        [HttpPost("pc/add")]
        public async Task<ActionResult<List<Itot_Pc>>> CreatePc([FromBody] Itot_PcDto dto)
        {
            if (dto == null)
            {
                return BadRequest("PC data is required.");
            }

            // Set date_created and date_updated to the current date/time in the "Asia/Manila" time zone
            var phTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Manila");

            var pc = new Itot_Pc
            {
                asset_barcode = dto.asset_barcode,
                date_acquired = dto.date_acquired,
                pc_type = dto.pc_type,
                brand = dto.brand,
                model = dto.model,
                processor = dto.processor,
                ram = dto.ram,
                storage_capacity = dto.storage_capacity,
                storage_type = dto.storage_type,
                operating_system = dto.operating_system,
                graphics = dto.graphics,
                size = dto.size,
                color = dto.color,
                li_description = $"{dto.pc_type} {dto.processor} {dto.ram} {dto.storage_capacity} {dto.storage_type} {dto.color}",
                serial_no = dto.serial_no,
                assigned = dto.assigned,
                status = dto.status,
                history = dto.history,
                date_created = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone),
                date_updated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone)
            };

            // Add the new PC entry to the database
            _context.Itot_Pcs.Add(pc);
            await _context.SaveChangesAsync();

            return Ok(await _context.Itot_Pcs.ToListAsync());
        }

        [HttpPut("pc/update/{id}")]
        public async Task<ActionResult<Itot_Pc>> UpdatePc(int id, [FromBody] Itot_PcDto dto)
        {
            if (dto == null)
            {
                return BadRequest("PC data is required.");
            }

            // Find the existing PC by ID
            var existingPc = await _context.Itot_Pcs
                                            .FirstOrDefaultAsync(p => p.id == id);

            if (existingPc == null)
            {
                return NotFound($"PC with ID {id} not found.");
            }

            // Check if the asset barcode is being changed and if it already exists
            if (existingPc.asset_barcode != dto.asset_barcode)
            {
                var barcodeExists = await _context.Itot_Pcs
                                                  .AnyAsync(p => p.asset_barcode == dto.asset_barcode);
                if (barcodeExists)
                {
                    return BadRequest("A PC with the same asset barcode already exists.");
                }
            }

            // Update the properties of the existing PC
            existingPc.asset_barcode = dto.asset_barcode;
            existingPc.date_acquired = dto.date_acquired;
            existingPc.pc_type = dto.pc_type;
            existingPc.brand = dto.brand;
            existingPc.model = dto.model;
            existingPc.processor = dto.processor;
            existingPc.ram = dto.ram;
            existingPc.storage_capacity = dto.storage_capacity;
            existingPc.storage_type = dto.storage_type;
            existingPc.operating_system = dto.operating_system;
            existingPc.graphics = dto.graphics;
            existingPc.size = dto.size;
            existingPc.color = dto.color;
            existingPc.li_description = dto.li_description;
            existingPc.serial_no = dto.serial_no;
            existingPc.assigned = dto.assigned;
            existingPc.status = dto.status;
            existingPc.history = dto.history;

            // Update the date_updated field with the current date and time in Manila time zone
            var phTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Manila");
            existingPc.date_updated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);

            // Save changes to the database
            _context.Itot_Pcs.Update(existingPc);
            await _context.SaveChangesAsync();

            return Ok(existingPc); // Return the updated entity to confirm successful update
        }


        // itot peripherals
        [HttpGet("peripherals")]
        public async Task<ActionResult<IEnumerable<Itot_Peripheral>>> GetAllPeripherals()
        {
            var items = await _context.Itot_Peripherals.ToListAsync(); // Use your DbSet for Itot_Pc
            return Ok(items); // Return 200 OK with the list of items
        }


        [HttpGet("peripherals/{id}")]
        public async Task<ActionResult<Itot_Peripheral>> GetByIdPeripherals(int id)
        {
            var item = await _context.Itot_Peripherals.FindAsync(id); // Find the item by ID

            if (item == null)
            {
                return NotFound(); // Return 404 Not Found if the item doesn't exist
            }

            return Ok(item); // Return 200 OK with the item
        }

        [HttpDelete("peripherals/delete/{id}")]
        public async Task<ActionResult> DeletePeripheral(int id)
        {
            // Find the peripheral by its ID
            var peripheral = await _context.Itot_Peripherals.FindAsync(id);

            // Check if the peripheral exists
            if (peripheral == null)
            {
                return NotFound(new { message = "Peripheral not found." });  // Return JSON response
            }

            // Remove the peripheral from the database
            _context.Itot_Peripherals.Remove(peripheral);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Peripheral deleted successfully." });  // Return JSON response
        }


        [HttpPost("peripherals/add")]
        public async Task<ActionResult<List<Itot_Peripheral>>> CreatePeripheral([FromBody] Itot_PeripheralDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Peripheral data is required.");
            }

            // Check for existing peripheral with the same asset barcode
            var existingPeripheral = await _context.Itot_Peripherals
                                                   .FirstOrDefaultAsync(p => p.asset_barcode == dto.asset_barcode);

            if (existingPeripheral != null)
            {
                return BadRequest("A peripheral with the same asset barcode already exists.");
            }

            var phTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Manila");

            var peripheral = new Itot_Peripheral
            {
                date_acquired = dto.date_acquired,
                asset_barcode = dto.asset_barcode,
                peripheral_type = dto.peripheral_type,
                li_description = $"{dto.brand} {dto.peripheral_type} {dto.color}", // Set automatically
                size = dto.size,
                brand = dto.brand,
                model = dto.model,
                color = dto.color,
                serial_no = dto.serial_no,
                assigned = "Assigned",
                status = "Active",
                history = dto.history,
            };

            _context.Itot_Peripherals.Add(peripheral);
            await _context.SaveChangesAsync();

            return Ok(await _context.Itot_Peripherals.ToListAsync());
        }


        [HttpPut("peripherals/update/{id}")]
        public async Task<ActionResult<Itot_Peripheral>> UpdatePeripheral(int id, [FromBody] Itot_PeripheralDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Peripheral data is required.");
            }

            // Find the peripheral by id
            var existingPeripheral = await _context.Itot_Peripherals
                                                    .FirstOrDefaultAsync(p => p.id == id);

            if (existingPeripheral == null)
            {
                return NotFound($"Peripheral with id {id} not found.");
            }

            // Optionally, check if the asset barcode is being changed and already exists
            if (existingPeripheral.asset_barcode != dto.asset_barcode)
            {
                var barcodeExists = await _context.Itot_Peripherals
                                                   .AnyAsync(p => p.asset_barcode == dto.asset_barcode);
                if (barcodeExists)
                {
                    return BadRequest("A peripheral with the same asset barcode already exists.");
                }
            }

            // Update the properties of the existing peripheral
            existingPeripheral.date_acquired = dto.date_acquired;
            existingPeripheral.asset_barcode = dto.asset_barcode;
            existingPeripheral.peripheral_type = dto.peripheral_type;
            existingPeripheral.li_description = dto.li_description;
            existingPeripheral.size = dto.size;
            existingPeripheral.brand = dto.brand;
            existingPeripheral.model = dto.model;
            existingPeripheral.color = dto.color;
            existingPeripheral.serial_no = dto.serial_no;
            existingPeripheral.history = dto.history;

            // Optional: If you want to modify other fields like 'assigned' or 'status', you can add that here
            // For example, you can keep 'assigned' as "Assigned" or allow changes based on the dto

            // Save changes to the database
            _context.Itot_Peripherals.Update(existingPeripheral);
            await _context.SaveChangesAsync();

            return Ok(existingPeripheral);
        }
    }
}
