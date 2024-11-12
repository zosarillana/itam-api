using ITAM_DB.Data.Computers;
using ITAM_DB.Data.Peripherals;
using ITAM_DB.Data.Sets;
using ITAM_DB.Dto.Peripherals;
using ITAM_DB.Dto.Sets;
using ITAM_DB.Model.Peripherals;
using ITAM_DB.Model.Sets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITAM_DB.Controllers.Sets
{
    [ApiController]
    [Route("[controller]")]
    public class DesktopSetController : Controller
    {
        private readonly DesktopSetContext _context;
        public DesktopSetController(DesktopSetContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DesktopSet>>> GetAllDesktopSets()
        {
            var avrs = await _context.DesktopSets.ToListAsync(); // Use your DbSet for AVR
            return Ok(avrs); // Return 200 OK with the list of items
        }

        [HttpPost]
        public async Task<ActionResult<List<DesktopSet>>> CreateDesktopSet(DesktopSetDto dto)
        {
            if (dto == null)
            {
                return BadRequest("DesktopSet Data is Required,");
            }

            var set = new DesktopSet
            {
                desktop_id = dto.desktop_id,
                avr_id = dto.avr_id,
                dongle_id = dto.dongle_id,
                keyboard_id = dto.keyboard_id,
                lanAdapter_id = dto.lanAdapter_id,
                monitor_id = dto.monitor_id,
                mouse_id = dto.mouse_id,
                ups_id = dto.ups_id,
                webcam_id = dto.webcam_id,
                status = dto.status,
                user_id = dto.user_id,
                li_description = dto.li_description,
                acquired_date = dto.acquired_date,
                
            };
            _context.DesktopSets.Add(set);
            await _context.SaveChangesAsync();

            return Ok(await _context.DesktopSets.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<DesktopSet>>> UpdateDesktopSet(int id, DesktopSetDto dto)
        {
            if (dto == null)
            {
                return BadRequest("DesktopSet data is required.");
            }

            // Find the existing AVR entity by ID
            var set = await _context.DesktopSets.FindAsync(id);
            if (set == null)
            {
                return NotFound($"No DesktopSet found with ID {id}.");
            }

            // Update the AVR properties
            set.desktop_id = dto.desktop_id;
            set.avr_id = dto.avr_id;
            set.dongle_id = dto.dongle_id;
            set.keyboard_id = dto.keyboard_id;
            set.lanAdapter_id = dto.lanAdapter_id;
            set.monitor_id = dto.monitor_id;
            set.mouse_id = dto.mouse_id;
            set.ups_id = dto.ups_id;
            set.webcam_id = dto.webcam_id;
            set.status = dto.status;
            set.user_id = dto.user_id;
            set.li_description = dto.li_description;
            set.acquired_date = dto.acquired_date;
            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.DesktopSets.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<DesktopSet>>> DeleteDesktopSet(int id)
        {
            // Find the existing AVR entity by ID
            var avr = await _context.DesktopSets.FindAsync(id);
            if (avr == null)
            {
                return NotFound($"No DesktopSet found with ID {id}.");
            }

            // Remove the AVR from the database
            _context.DesktopSets.Remove(avr);
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.DesktopSets.ToListAsync());
        }

    }
}
