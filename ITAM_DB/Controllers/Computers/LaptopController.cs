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
    public class LaptopController : Controller
    {
        private readonly LaptopContext _context;
        public LaptopController(LaptopContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Laptop>>> GetAllLaptop()
        {
            var avrs = await _context.Laptops.ToListAsync(); // Use your DbSet for AVR
            return Ok(avrs); // Return 200 OK with the list of items
        }

        [HttpPost]
        public async Task<ActionResult<List<Laptop>>> CreateLaptop(LaptopDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Laptop Data is Required,");
            }

            var lpt = new Laptop
            {
                brand = dto.model,
                model = dto.color,
                processor = dto.brand,
                ram = dto.status,
                storage_capacity = dto.assigned,
                storage_type = dto.li_description,
                operating_system = dto.li_description,
                graphics = dto.li_description,
                size = dto.li_description,
                color = dto.li_description,               
                status = "Active",
                assigned = "Not Assigned",
                user_history = "0",
                li_description = $"{dto.brand} {dto.model} {dto.processor} {dto.ram} {dto.storage_capacity} {dto.storage_type} {dto.operating_system} {dto.graphics} {dto.color}",
                acquired_date = dto.acquired_date,
                asset_barcode = dto.asset_barcode,
                serial_no = dto.serial_no,
            };
            _context.Laptops.Add(lpt);
            await _context.SaveChangesAsync();

            return Ok(await _context.Laptops.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Laptop>>> UpdateLaptop(int id, LaptopDto dto)
        {
            if (dto == null)
            {
                return BadRequest("AVR data is required.");
            }

            // Find the existing AVR entity by ID
            var lpt = await _context.Laptops.FindAsync(id);
            if (lpt == null)
            {
                return NotFound($"No AVR found with ID {id}.");
            }

            // Update the AVR properties
            lpt.brand = dto.model;
            lpt.model = dto.color;
            lpt.processor = dto.brand;
            lpt.ram = dto.status;
            lpt.storage_capacity = dto.assigned;
            lpt.storage_type = dto.li_description;
            lpt.operating_system = dto.li_description;
            lpt.graphics = dto.li_description;
            lpt.size = dto.li_description;
            lpt.color = dto.li_description;
            lpt.status = dto.li_description;
            lpt.assigned = dto.li_description;
            lpt.acquired_date = dto.acquired_date;
            lpt.asset_barcode = dto.asset_barcode;
            lpt.serial_no = dto.serial_no;

            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.Laptops.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Laptop>>> DeleteLaptop(int id)
        {
            // Find the existing AVR entity by ID
            var lpt = await _context.Laptops.FindAsync(id);
            if (lpt == null)
            {
                return NotFound($"No AVR found with ID {id}.");
            }

            // Remove the AVR from the database
            _context.Laptops.Remove(lpt);
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.Laptops.ToListAsync());
        }
    }
}
