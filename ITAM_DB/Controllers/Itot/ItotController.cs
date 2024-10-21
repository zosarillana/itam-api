using ITAM_API.Data;
using ITAM_API.Data.Itot;
using ITAM_API.Model.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITAM_DB.Controllers.Itot
{
    [ApiController]
    [Route("[controller]")]
    public class ItotController : ControllerBase
    {
        private readonly ItotContext _context; // Your DbContext
        private readonly ILogger<ImportItotController> _logger;
        public ItotController(ItotContext context, ILogger<ImportItotController> logger)
        {
            _context = context;   
            _logger = logger;
        }
        // GET: /itot
        [HttpGet("pc")]
        public async Task<ActionResult<IEnumerable<Itot_Pc>>> GetAll()
        {
            var items = await _context.Itot_Pcs.ToListAsync(); // Use your DbSet for Itot_Pc
            return Ok(items); // Return 200 OK with the list of items
        }

        // GET: /itot/{id}
        [HttpGet("pc/{id}")]
        public async Task<ActionResult<Itot_Pc>> GetById(int id)
        {
            var item = await _context.Itot_Pcs.FindAsync(id); // Find the item by ID

            if (item == null)
            {
                return NotFound(); // Return 404 Not Found if the item doesn't exist
            }

            return Ok(item); // Return 200 OK with the item
        }

        // GET: /itot
        [HttpGet("peripherals")]
        public async Task<ActionResult<IEnumerable<Itot_Peripheral>>> GetAllPeripherals()
        {
            var items = await _context.Itot_Peripherals.ToListAsync(); // Use your DbSet for Itot_Pc
            return Ok(items); // Return 200 OK with the list of items
        }

        // GET: /itot/{id}
        [HttpGet("peripherals/{id}")]
        public async Task<ActionResult<Itot_Peripheral>> GetByIdPeripherals(int id)
        {
            var item = await _context.Itot_Peripherals.FindAsync(id); // Find the item by ID

            if (item == null)
            {
                return NotFound(); // Return 404 Not Found if the item doesn't exist
            }

            return Ok(item); // Return 200 OK with the item
        }
    }
}
