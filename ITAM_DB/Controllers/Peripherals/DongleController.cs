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
        public async Task<ActionResult<List<Dongle>>> CreateDongle(DongleDto     dto)
        {
          

            var dongle = new Dongle
            {
                model = dto.model,
                color = dto.color,
                brand = dto.brand,
                status = "Active",
                assigned = "Not Assigned",
                user_history = "",
                set_history = "",
                li_description = $"{dto.color} {dto.brand} {dto.type}",
                acquired_date = dto.acquired_date,
                asset_barcode = dto.asset_barcode,
                serial_no = dto.serial_no,
            };
            _context.Dongles.Add(dongle);
            await _context.SaveChangesAsync();

            return Ok(await _context.Dongles.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Dongle>>> UpdateDongle(int id, Dongle dto)
        {          

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
            dongle.status = dto.status;
            dongle.type = dto.type;
            dongle.assigned = dto.assigned;
            dongle.li_description = dto.li_description;
            dongle.acquired_date = dto.acquired_date;
            dongle.asset_barcode = dto.asset_barcode;
            dongle.serial_no = dto.serial_no;

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
