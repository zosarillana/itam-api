using ITAM_DB.Data.Computers;
using ITAM_DB.Data.Peripherals;
using ITAM_DB.Dto.Computers;
using ITAM_DB.Dto.Peripherals;
using ITAM_DB.Model.Computers;
using ITAM_DB.Model.Peripherals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.Intrinsics.Arm;

namespace ITAM_DB.Controllers.Computers
{
    [ApiController]
    [Route("[controller]")]
    public class DesktopController : Controller
    {
        private readonly DesktopContext _context;
        public DesktopController(DesktopContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Desktop>>> GetAllDesktop()
        {
            var avrs = await _context.Desktops.ToListAsync(); // Use your DbSet for AVR
            return Ok(avrs); // Return 200 OK with the list of items
        }

        [HttpPost]
        public async Task<ActionResult<List<Desktop>>> CreateDesktop(DesktopDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Desktop Data is Required,");
            }

            var dsktp = new Desktop
            {
            brand = dto.brand,
            model = dto.model,
            processor = dto.processor,
            ram = dto.ram,
            storage_capacity = dto.storage_capacity,
            storage_type = dto.storage_type,
            operating_system = dto.operating_system,
            graphics = dto.graphics,
            color = dto.color,
            status = dto.status,
            assigned = dto.assigned,
            li_description = dto.li_description,
            acquired_date = dto.acquired_date,
            asset_barcode = dto.asset_barcode,
            serial_no = dto.serial_no,
            };
            _context.Desktops.Add(dsktp);
            await _context.SaveChangesAsync();

            return Ok(await _context.Desktops.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Desktop>>> UpdateDesktop(int id, DesktopDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Desktop data is required.");
            }

            // Find the existing AVR entity by ID
            var dsktp = await _context.Desktops.FindAsync(id);
            if (dsktp == null)
            {
                return NotFound($"No Desktop found with ID {id}.");
            }

            // Update the AVR properties        
            dsktp.brand = dto.brand;
            dsktp.model = dto.model;
            dsktp.processor = dto.processor;
            dsktp.ram = dto.ram;
            dsktp.storage_capacity = dto.storage_capacity;
            dsktp.storage_type = dto.storage_type;
            dsktp.operating_system = dto.operating_system;
            dsktp.graphics = dto.graphics;
            dsktp.color = dto.color;
            dsktp.status = dto.status;
            dsktp.assigned = dto.assigned;
            dsktp.li_description = dto.li_description;
            dsktp.acquired_date = dto.acquired_date;
            dsktp.asset_barcode = dto.asset_barcode;
            dsktp.serial_no = dto.serial_no;
            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.Desktops.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Desktop>>> DeleteAVR(int id)
        {
            // Find the existing AVR entity by ID
            var avr = await _context.Desktops.FindAsync(id);
            if (avr == null)
            {
                return NotFound($"No Desktop found with ID {id}.");
            }

            // Remove the AVR from the database
            _context.Desktops.Remove(avr);
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.Desktops.ToListAsync());
        }
    }
}
