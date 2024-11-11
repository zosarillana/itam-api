using ITAM_DB.Data.Peripherals;
using ITAM_DB.Dto.Peripherals;
using ITAM_DB.Model.Peripherals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITAM_DB.Controllers.Peripherals
{
    [ApiController]
    [Route("[controller]")]
    public class KeyboardController : Controller
    {
        private readonly KeyboardContext _context;
        public KeyboardController(KeyboardContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Keyboard>>> GetAllKeyboard()
        {
            var avrs = await _context.Keyboards.ToListAsync(); // Use your DbSet for AVR
            return Ok(avrs); // Return 200 OK with the list of items
        }

        [HttpPost]
        public async Task<ActionResult<List<Keyboard>>> CreateKeboard(KeyboardDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Keyboard Data is Required,");
            }

            var keyboard = new Keyboard
            {
                model = dto.model,
                color = dto.color,
                brand = dto.brand,
                type = dto.type,
                assetCode = dto.assetCode,
                acqDate = dto.acqDate,
                srlNumber = dto.srlNumber,
            };
            _context.Keyboards.Add(keyboard);
            await _context.SaveChangesAsync();

            return Ok(await _context.Keyboards.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Keyboard>>> UpdateKeyboard(int id, KeyboardDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Keyboard data is required.");
            }

            // Find the existing AVR entity by ID
            var keyboard = await _context.Keyboards.FindAsync(id);
            if (keyboard == null)
            {
                return NotFound($"No Keyboard found with ID {id}.");
            }

            // Update the AVR properties
            keyboard.model = dto.model;
            keyboard.color = dto.color;
            keyboard.brand = dto.brand;
            keyboard.type = dto.type;
            keyboard.assetCode = dto.assetCode;
            keyboard.acqDate = dto.acqDate;
            keyboard.srlNumber = dto.srlNumber;

            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.Keyboards.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Keyboard>>> DeleteKeyboard(int id)
        {
            // Find the existing AVR entity by ID
            var keyboard = await _context.Keyboards.FindAsync(id);
            if (keyboard == null)
            {
                return NotFound($"No AVR found with ID {id}.");
            }

            // Remove the AVR from the database
            _context.Keyboards.Remove(keyboard);
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.Keyboards.ToListAsync());
        }

    }
}

