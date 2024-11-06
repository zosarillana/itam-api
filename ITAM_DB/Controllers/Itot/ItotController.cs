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
                li_description = dto.li_description,
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
        public async Task<ActionResult> UpdatePc(int id, [FromBody] Itot_PcDto dto)
        {
            if (dto == null)
            {
                return BadRequest("PC data is required.");
            }

            // Find the existing PC by ID
            var pc = await _context.Itot_Pcs.FindAsync(id);
            if (pc == null)
            {
                return NotFound($"PC with ID {id} not found.");
            }

            // Update the PC properties from the DTO
            pc.asset_barcode = dto.asset_barcode;
            pc.date_acquired = dto.date_acquired;
            pc.pc_type = dto.pc_type;
            pc.brand = dto.brand;
            pc.model = dto.model;
            pc.processor = dto.processor;
            pc.ram = dto.ram;
            pc.storage_capacity = dto.storage_capacity;
            pc.storage_type = dto.storage_type;
            pc.operating_system = dto.operating_system;
            pc.graphics = dto.graphics;
            pc.size = dto.size;
            pc.color = dto.color;
            pc.li_description = dto.li_description;
            pc.serial_no = dto.serial_no;
            pc.assigned = dto.assigned;
            pc.status = dto.status;
            pc.history = dto.history;

            // Update the date_updated field with the current date and time in Manila time zone
            var phTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Manila");
            pc.date_updated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);

            // Save changes to the database
            await _context.SaveChangesAsync();

            return NoContent(); // Return 204 No Content to indicate successful update
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
                li_description = dto.li_description,
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
