using ITAM_DB.Data.Peripherals;
using ITAM_DB.Dto.Peripherals;
using ITAM_DB.Model.Peripherals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITAM_DB.Controllers.Peripherals
{
    [ApiController]
    [Route("[controller]")]
    public class DongleController : Controller
    {
        public readonly DongleContext _context;

        public DongleController(DongleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dongle>>> GetAllAVR()
        {
            var avrs = await _context.Dongles.ToListAsync(); // Use your DbSet for AVR
            return Ok(avrs); // Return 200 OK with the list of items
        }

        [HttpPost]
        public async Task<ActionResult<List<Dongle>>> CreateDongle(DongleDto dto)
        {
            if (dto == null)
            {
                return BadRequest("AVR Data is Required,");
            }

            var dongle = new Dongle
            {
                model = dto.model,
                color = dto.color,
                brand = dto.brand,
                assetCode = dto.assetCode,
                acqDate = dto.acqDate,
                srlNumber = dto.srlNumber,
            };
            _context.Dongles.Add(dongle);
            await _context.SaveChangesAsync();

            return Ok(await _context.Dongles.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Dongle>>> UpdateDongle(int id, Dongle dto)
        {
            if (dto == null)
            {
                return BadRequest("Dongle data is required.");
            }

            // Find the existing AVR entity by ID
            var dongle = await _context.Dongles.FindAsync(id);
            if (dongle == null)
            {
                return NotFound($"No Dongle found with ID {id}.");
            }

            // Update the AVR properties
            dongle.model = dto.model;
            dongle.color = dto.color;
            dongle.brand = dto.brand;
            dongle.type = dto.type;
            dongle.assetCode = dto.assetCode;
            dongle.acqDate = dto.acqDate;
            dongle.srlNumber = dto.srlNumber;

            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.Dongles.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Dongle>>> DeleteDongle(int id)
        {
            // Find the existing AVR entity by ID
            var dongle = await _context.Dongles.FindAsync(id);
            if (dongle == null)
            {
                return NotFound($"No AVR found with ID {id}.");
            }

            // Remove the AVR from the database
            _context.Dongles.Remove(dongle);
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.Dongles.ToListAsync());
        }
    }
}
