using ITAM_DB.Data.Computers;
using ITAM_DB.Data.Sets;
using ITAM_DB.Dto.Computers;
using ITAM_DB.Dto.Sets;
using ITAM_DB.Model.Computers;
using ITAM_DB.Model.Sets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITAM_DB.Controllers.Sets
{
    [ApiController]
    [Route("[controller]")]
    public class LaptopSetController : Controller
    {
        private readonly LaptopSetContext _context;
        public LaptopSetController(LaptopSetContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<LaptopSet>>> GetAllLaptop()
        {
            var avrs = await _context.LaptopSets.ToListAsync(); // Use your DbSet for AVR
            return Ok(avrs); // Return 200 OK with the list of items
        }

        [HttpPost]
        public async Task<ActionResult<List<LaptopSet>>> CreateLaptop(LaptopSetDto dto)
        {
            if (dto == null)
            {
                return BadRequest("LaptopSet Data is Required,");
            }

            var set = new LaptopSet
            {
                desktop_id = dto.desktop_id,               
                dongle_id = dto.dongle_id,
                keyboard_id = dto.keyboard_id,
                lanAdapter_id = dto.lanAdapter_id,
                monitor_id = dto.monitor_id,
                mouse_id = dto.mouse_id,                
                webcam_id = dto.webcam_id,
                bag_id = dto.bag_id,
                externalDrive_id = dto.bag_id,
                user_id = dto.user_id,
                status = dto.status,                
                li_description = dto.li_description,
                acquired_date = dto.acquired_date,
            };
            _context.LaptopSets.Add(set);
            await _context.SaveChangesAsync();

            return Ok(await _context.LaptopSets.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<LaptopSet>>> UpdateLaptop(int id, LaptopSetDto dto)
        {
            if (dto == null)
            {
                return BadRequest("LaptopSet data is required.");
            }

            // Find the existing AVR entity by ID
            var set = await _context.LaptopSets.FindAsync(id);
            if (set == null)
            {
                return NotFound($"No LaptopSet found with ID {id}.");
            }

            // Update the AVR properties
            set.desktop_id = dto.desktop_id;
            set.dongle_id = dto.dongle_id;
            set.keyboard_id = dto.keyboard_id;
            set.lanAdapter_id = dto.lanAdapter_id;
            set.monitor_id = dto.monitor_id;
            set.mouse_id = dto.mouse_id;              
            set.webcam_id = dto.webcam_id;
            set.bag_id = dto.bag_id;
            set.externalDrive_id = dto.bag_id;
            set.user_id = dto.user_id;
            set.status = dto.status;
            set.li_description = dto.li_description;
            set.acquired_date = dto.acquired_date;

            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.LaptopSets.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<LaptopSet>>> DeleteLaptop(int id)
        {
            // Find the existing AVR entity by ID
            var lpt = await _context.LaptopSets.FindAsync(id);
            if (lpt == null)
            {
                return NotFound($"No AVR found with ID {id}.");
            }

            // Remove the AVR from the database
            _context.LaptopSets.Remove(lpt);
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.LaptopSets.ToListAsync());
        }
    }
}
