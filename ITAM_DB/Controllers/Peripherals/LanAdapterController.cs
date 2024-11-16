using ITAM_DB.Data.Computers;
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
    public class LanAdapterController : Controller
    {
        private readonly LanAdapterContext _context;
        public LanAdapterController(LanAdapterContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LanAdapter>>> GetAllLan()
        {
            var avrs = await _context.LanAdapters.ToListAsync(); // Use your DbSet for AVR
            return Ok(avrs); // Return 200 OK with the list of items
        }

        [HttpPost]
        public async Task<ActionResult<List<LanAdapter>>> CreateKeyboard(LanAdapterDto dto)
        {          

            var lanAdapter = new LanAdapter
            {
                model = dto.model,
                color = dto.color,
                brand = dto.brand,
                type = dto.type,
                status = "Active",
                assigned = "Not Assigned",
                user_history = "",
                set_history = "",
                li_description = $"{dto.model} {dto.color} {dto.brand} {dto.type}",
                acquired_date = dto.acquired_date,
                asset_barcode = dto.asset_barcode,
                serial_no = dto.serial_no,
            };
            _context.LanAdapters.Add(lanAdapter);
            await _context.SaveChangesAsync();

            return Ok(await _context.LanAdapters.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<LanAdapter>>> UpdateKeyboard(int id, LanAdapterDto dto)
        {
           
            // Find the existing AVR entity by ID
            var lanAdapter = await _context.LanAdapters.FindAsync(id);
            if (lanAdapter == null)
            {
                return NotFound($"No lanAdapter found with ID {id}.");
            }

            // Update the AVR properties
            lanAdapter.model = dto.model;
            lanAdapter.color = dto.color;
            lanAdapter.brand = dto.brand;
            lanAdapter.type = dto.type;
            lanAdapter.status = dto.status;
            lanAdapter.assigned = dto.assigned;
            lanAdapter.li_description = dto.li_description;
            lanAdapter.acquired_date = dto.acquired_date;
            lanAdapter.asset_barcode = dto.asset_barcode;
            lanAdapter.serial_no = dto.serial_no;

            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.LanAdapters.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Keyboard>>> DeleteKeyboard(int id)
        {
            // Find the existing AVR entity by ID
            var keyboard = await _context.LanAdapters.FindAsync(id);
            if (keyboard == null)
            {
                return NotFound($"No lanAdapter found with ID {id}.");
            }

            // Remove the AVR from the database
            _context.LanAdapters.Remove(keyboard);
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.LanAdapters.ToListAsync());
        }
    }
}