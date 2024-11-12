using ITAM_API.Model.Operations;
using ITAM_DB.Data.Peripherals;
using ITAM_DB.Dto.Peripherals;
using ITAM_DB.Model.Peripherals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace ITAM_DB.Controllers.Peripherals
{
    [ApiController]
    [Route("[controller]")]
    public class AVRController : Controller
    {
        private readonly AVRContext _context;
        public AVRController(AVRContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AVR>>> GetAllAVR()
        {
            var avrs = await _context.AVRs.ToListAsync(); // Use your DbSet for AVR
            return Ok(avrs); // Return 200 OK with the list of items
        }

        [HttpPost]
        public async Task<ActionResult<List<AVR>>> CreateAVR( AVRDto dto)
        {
            if (dto == null)
            {
                return BadRequest("AVR Data is Required,");
            }

            var avr = new AVR
            {
                model = dto.model,
                color = dto.color,
                brand = dto.brand,
                status = "Active",
                assigned = "Not Assigned",
                user_history = "0",
                set_history = "0",
                li_description = $"{dto.model} {dto.color}  {dto.brand}",
                acquired_date = dto.acquired_date,
                asset_barcode = dto.asset_barcode,
                serial_no = dto.serial_no,
            };
            _context.AVRs.Add(avr);
            await _context.SaveChangesAsync();

            return Ok(await _context.AVRs.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<AVR>>> UpdateAVR(int id, AVRDto dto)
        {
            if (dto == null)
            {
                return BadRequest("AVR data is required.");
            }

            // Find the existing AVR entity by ID
            var avr = await _context.AVRs.FindAsync(id);
            if (avr == null)
            {
                return NotFound($"No AVR found with ID {id}.");
            }

            // Update the AVR properties
            avr.model = dto.model;
            avr.color = dto.color;
            avr.brand = dto.brand;
            avr.status = dto.status;
            avr.assigned = dto.assigned;
            avr.user_history = dto.assigned;
            avr.set_history = dto.assigned;
            avr.li_description = dto.li_description;
            avr.acquired_date = dto.acquired_date;
            avr.asset_barcode = dto.asset_barcode;
            avr.serial_no = dto.serial_no;

            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.AVRs.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<AVR>>> DeleteAVR(int id)
        {
            // Find the existing AVR entity by ID
            var avr = await _context.AVRs.FindAsync(id);
            if (avr == null)
            {
                return NotFound($"No AVR found with ID {id}.");
            }

            // Remove the AVR from the database
            _context.AVRs.Remove(avr);
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.AVRs.ToListAsync());
        }

    }
}

