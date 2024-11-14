using ITAM_DB.Data.Peripherals;
using ITAM_DB.Data.User;
using ITAM_DB.Dto.Peripherals;
using ITAM_DB.Dto.User;
using ITAM_DB.Model.Peripherals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserModel = ITAM_DB.Model.User.User;

namespace ITAM_DB.Controllers.User
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly UserContext _context;
        public UserController(UserContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetAllUser()
        {
            var users = await _context.Users.ToListAsync(); // Use your DbSet for AVR
            return Ok(users); // Return 200 OK with the list of items
        }

        [HttpPost]
        public async Task<ActionResult<List<UserModel>>> CreateUser(UserDto dto)
        {
            if (dto == null)
            {
                return BadRequest("User Data is Required,");
            }

            var user = new UserModel
            {
                first_name = dto.first_name,
                middle_name = dto.middle_name,
                last_name = dto.last_name,
                emp_id = dto.emp_id,
                contact_no = dto.contact_no,
                position = dto.position,
                dept_name = dto.dept_name,
                company_name = dto.company_name,
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(await _context.Users.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<UserModel>>> UpdateUser(int id, UserDto dto)
        {
            if (dto == null)
            {
                return BadRequest("User data is required.");
            }

            // Find the existing AVR entity by ID
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound($"No User found with ID {id}.");
            }

            // Update the AVR properties
            user.first_name = dto.first_name;
            user.middle_name = dto.middle_name;
            user.last_name = dto.last_name;
            user.emp_id = dto.emp_id;
            user.contact_no = dto.contact_no;
            user.position = dto.position;
            user.dept_name = dto.dept_name;
            user.company_name = dto.company_name;

            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UserModel>>> DeleteAVR(int id)
        {
            // Find the existing AVR entity by ID
            var avr = await _context.Users.FindAsync(id);
            if (avr == null)
            {
                return NotFound($"No User found with ID {id}.");
            }

            // Remove the AVR from the database
            _context.Users.Remove(avr);
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.Users.ToListAsync());
        }

    }
}

