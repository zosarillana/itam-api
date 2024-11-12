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
    public class UPSController : Controller
    {
        private readonly UPSContext _context;
        public UPSController(UPSContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UPS>>> GetAllUPS()
        {
            var ups = await _context.UPSs.ToListAsync(); // Use your DbSet for AVR
            return Ok(ups); // Return 200 OK with the list of items
        }

        [HttpPost]
        public async Task<ActionResult<List<UPS>>> CreateUPS(UPSDto dto)
        {
            if (dto == null)
            {
                return BadRequest("UPS Data is Required,");
            }

            var ups = new UPS
            {
                model = dto.model,
                color = dto.color,
                brand = dto.brand,
                status = "Active",
                assigned = "Not Assigned",
                user_history = "0",
                set_history = "0",
                li_description = $"{dto.model} {dto.color} {dto.brand} {dto.model}",
                acquired_date = dto.acquired_date,
                asset_barcode = dto.asset_barcode,
                serial_no = dto.serial_no,
            };
            _context.UPSs.Add(ups);
            await _context.SaveChangesAsync();

            return Ok(await _context.UPSs.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<UPS>>> UpdateAVR(int id, UPSDto dto)
        {
            if (dto == null)
            {
                return BadRequest("UPS data is required.");
            }

            // Find the existing AVR entity by ID
            var ups = await _context.UPSs.FindAsync(id);
            if (ups == null)
            {
                return NotFound($"No UPS found with ID {id}.");
            }

            // Update the AVR properties
            ups.model = dto.model;
            ups.color = dto.color;
            ups.brand = dto.brand;
            ups.status = dto.status;
            ups.assigned = dto.assigned;
            ups.li_description = dto.li_description;
            ups.acquired_date = dto.acquired_date;
            ups.asset_barcode = dto.asset_barcode;
            ups.serial_no = dto.serial_no;

            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.UPSs.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UPS>>> DeleteUPS(int id)
        {
            // Find the existing AVR entity by ID
            var ups = await _context.UPSs.FindAsync(id);
            if (ups == null)
            {
                return NotFound($"No AVR found with ID {id}.");
            }

            // Remove the AVR from the database
            _context.UPSs.Remove(ups);
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.UPSs.ToListAsync());
        }

    }
}
