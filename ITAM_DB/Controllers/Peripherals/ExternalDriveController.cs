using ITAM_DB.Data.Peripherals;
using ITAM_DB.Dto.Peripherals;
using ITAM_DB.Model.Peripherals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                assetCode = dto.assetCode,
                acqDate = dto.acqDate,
                srlNumber = dto.srlNumber,
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
            exdrive.type = dto.type;
            exdrive.assetCode = dto.assetCode;
            exdrive.acqDate = dto.acqDate;
            exdrive.srlNumber = dto.srlNumber;

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

