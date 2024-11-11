using ITAM_DB.Data.Peripherals;
using ITAM_DB.Dto.Peripherals;
using ITAM_DB.Model.Peripherals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITAM_DB.Controllers.Peripherals
{

    [ApiController]
    [Route("[controller]")]
    public class MonitorController : Controller
    {
        private readonly MonitorContext _context;
        public MonitorController(MonitorContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ITAM_DB.Model.Peripherals.Monitor>>> GetAllMonitor()
        {
            var avrs = await _context.Monitors.ToListAsync();
            return Ok(avrs);
        }

        [HttpPost]
        public async Task<ActionResult<List<ITAM_DB.Model.Peripherals.Monitor>>> CreateMonitor(MonitorDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Monitor Data is Required.");
            }

            var monitor = new ITAM_DB.Model.Peripherals.Monitor
            {
                size = dto.size,
                model = dto.model,
                color = dto.color,
                brand = dto.brand,
                assetCode = dto.assetCode,
                acqDate = dto.acqDate,
                srlNumber = dto.srlNumber,
            };

            _context.Monitors.Add(monitor);  // Use the local variable 'monitor' here
            await _context.SaveChangesAsync();

            return Ok(await _context.Monitors.ToListAsync());
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<ITAM_DB.Model.Peripherals.Monitor>>> UpdateMonitor(int id, MonitorDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Monitor data is required.");
            }

            // Find the existing AVR entity by ID
            var monitor = await _context.Monitors.FindAsync(id);
            if (monitor == null)
            {
                return NotFound($"No Monitor found with ID {id}.");
            }

            // Update the AVR properties
            monitor.size = dto.size;
            monitor.model = dto.model;
            monitor.color = dto.color;
            monitor.brand = dto.brand;
            monitor.assetCode = dto.assetCode;
            monitor.acqDate = dto.acqDate;
            monitor.srlNumber = dto.srlNumber;

            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.Monitors.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ITAM_DB.Model.Peripherals.Monitor>>> DeleteMonitor(int id)
        {
            // Find the existing AVR entity by ID
            var keyboard = await _context.Monitors.FindAsync(id);
            if (keyboard == null)
            {
                return NotFound($"No AVR found with ID {id}.");
            }

            // Remove the AVR from the database
            _context.Monitors.Remove(keyboard);
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.Monitors.ToListAsync());
        }

    }
}

