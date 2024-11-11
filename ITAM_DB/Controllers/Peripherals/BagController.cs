using ITAM_DB.Data.Peripherals;
using ITAM_DB.Dto.Peripherals;
using ITAM_DB.Model.Peripherals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITAM_DB.Controllers.Peripherals
{
    [ApiController]
    [Route("[controller]")]
    public class BagController : Controller
    {
        private readonly BagContext _context;
        public BagController(BagContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bag>>> GetAllBag()
        {
            var bags = await _context.Bags.ToListAsync(); // Use your DbSet for AVR
            return Ok(bags); // Return 200 OK with the list of items
        }

        [HttpPost]
        public async Task<ActionResult<List<Bag>>> CreateBag(BagDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Bag Data is Required,");
            }

            var bag = new Bag
            {
                color = dto.color,
                brand = dto.brand,
                type = dto.type,
                assetCode = dto.assetCode,
                acqDate = dto.acqDate,
                srlNumber = dto.srlNumber,
            };
            _context.Bags.Add(bag);
            await _context.SaveChangesAsync();

            return Ok(await _context.Bags.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Bag>>> UpdateBag(int id, BagDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Bag data is required.");
            }

            // Find the existing AVR entity by ID
            var bag = await _context.Bags.FindAsync(id);
            if (bag == null)
            {
                return NotFound($"No Bag found with ID {id}.");
            }

            // Update the AVR properties            
            bag.color = dto.color;
            bag.brand = dto.brand;
            bag.type = dto.type;
            bag.assetCode = dto.assetCode;
            bag.acqDate = dto.acqDate;
            bag.srlNumber = dto.srlNumber;

            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.Bags.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Bag>>> DeleteBag(int id)
        {
            // Find the existing AVR entity by ID
            var bag = await _context.Bags.FindAsync(id);
            if (bag == null)
            {
                return NotFound($"No Bag found with ID {id}.");
            }

            // Remove the AVR from the database
            _context.Bags.Remove(bag);
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.Bags.ToListAsync());
        }
    }
}
