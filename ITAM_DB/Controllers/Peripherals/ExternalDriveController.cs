using ITAM_DB.Data.Peripherals;
using ITAM_DB.Dto.Peripherals;
using ITAM_DB.Model.Peripherals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace ITAM_DB.Controllers.Peripherals
{
    [ApiController]
    [Route("[controller]")]
    public class ExternalDriveController : Controller
    {
        private readonly ExternalDriveContext _context;
        public ExternalDriveController(ExternalDriveContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExternalDrive>>> GetAllExDrive()
        {
            var dongles = await _context.ExternalDrives.ToListAsync(); // Use your DbSet for AVR
            return Ok(dongles); // Return 200 OK with the list of items
        }

        [HttpPost]
        public async Task<ActionResult<List<ExternalDrive>>> CreateExDrive(ExternalDriveDto dto)
        {
            if (dto == null)
            {
                return BadRequest("ExternalDrive Data is Required,");
            }

            var dongles = new ExternalDrive
            {
                model = dto.model,
                color = dto.color,
                brand = dto.brand,
                type = dto.type,
                status = "Active",
                assigned = "Not Assigned",
                user_history = "0",
                set_history = "0",
                li_description = $"{dto.color} {dto.brand}  {dto.type}",
                acquired_date = dto.acquired_date,
                asset_barcode = dto.asset_barcode,
                serial_no = dto.serial_no,
            };
            _context.ExternalDrives.Add(dongles);
            await _context.SaveChangesAsync();

            return Ok(await _context.ExternalDrives.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<ExternalDrive>>> UpdateExDrive(int id, ExternalDriveDto dto)
        {
            if (dto == null)
            {
                return BadRequest("ExternalDrive data is required.");
            }

            // Find the existing AVR entity by ID
            var exdrive = await _context.ExternalDrives.FindAsync(id);
            if (exdrive == null)
            {
                return NotFound($"No ExternalDrive found with ID {id}.");
            }

            // Update the AVR properties
            exdrive.model = dto.model;
            exdrive.color = dto.color;
            exdrive.brand = dto.brand;
            exdrive.status = dto.status;
            exdrive.type = dto.type;
            exdrive.assigned = dto.assigned;
            exdrive.li_description = dto.li_description;
            exdrive.acquired_date = dto.acquired_date;
            exdrive.asset_barcode = dto.asset_barcode;
            exdrive.serial_no = dto.serial_no;

            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.ExternalDrives.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ExternalDrive>>> DeleteExDrive(int id)
        {
            // Find the existing AVR entity by ID
            var exdrive = await _context.ExternalDrives.FindAsync(id);
            if (exdrive == null)
            {
                return NotFound($"No ExternalDrive found with ID {id}.");
            }

            // Remove the AVR from the database
            _context.ExternalDrives.Remove(exdrive);
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.ExternalDrives.ToListAsync());
        }

    }
}

