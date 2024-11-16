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
    public class MouseController : Controller
    {
        private readonly MouseContext _context;
        public MouseController(MouseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mouse>>> GetAllMouse()
        {
            var avrs = await _context.Mouses.ToListAsync(); // Use your DbSet for AVR
            return Ok(avrs); // Return 200 OK with the list of items
        }

        [HttpPost]
        public async Task<ActionResult<List<Mouse>>> CreateMOuse(MouseDto dto)
        {
            if (dto == null)
            {
                return BadRequest("AVR Data is Required,");
            }

            var mouse = new Mouse
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
            _context.Mouses.Add(mouse);
            await _context.SaveChangesAsync();

            return Ok(await _context.Mouses.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Mouse>>> UpdateMouses(int id, MouseDto dto)
        {
            if (dto == null)
            {
                return BadRequest("AVR data is required.");
            }

            // Find the existing AVR entity by ID
            var mouse = await _context.Mouses.FindAsync(id);
            if (mouse == null)
            {
                return NotFound($"No AVR found with ID {id}.");
            }

            // Update the AVR properties
            mouse.model = dto.model;
            mouse.color = dto.color;
            mouse.type = dto.type;
            mouse.brand = dto.brand;
            mouse.status = dto.status;
            mouse.li_description = dto.li_description;
            mouse.acquired_date = dto.acquired_date;
            mouse.asset_barcode = dto.asset_barcode;
            mouse.serial_no = dto.serial_no;
            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.Mouses.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Mouse>>> DeleteMouse(int id)
        {
            // Find the existing AVR entity by ID
            var mouse = await _context.Mouses.FindAsync(id);
            if (mouse == null)
            {
                return NotFound($"No AVR found with ID {id}.");
            }

            // Remove the AVR from the database
            _context.Mouses.Remove(mouse);
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.Mouses.ToListAsync());
        }

    }
}
