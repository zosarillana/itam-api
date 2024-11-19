using ITAM_API.Data;
using ITAM_API.Model.Operations;
using ITAM_DB.Data.Peripherals;
using ITAM_DB.Dto.Computers.Desktop;
using ITAM_DB.Dto.Peripherals.AVR;
using ITAM_DB.Dto.Peripherals.Monitor;
using ITAM_DB.Dto.Peripherals.Mouse;
using ITAM_DB.Dto.User;
using ITAM_DB.Model.Peripherals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace ITAM_DB.Controllers.Peripherals
{
    [ApiController]
    [Route("[controller]")]
    public class AVRController : Controller
    {
        private readonly ItotContext _context;
        public AVRController(ItotContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AVRWithIds>>> GetAllMonitor()
        {
            // Fetch all necessary data from the database
            var mouses = await _context.Mouses.ToListAsync();
            var users = await _context.Users.ToListAsync();
            var desktops = await _context.Desktops.ToListAsync();

            // Map the monitors to their DTO representation
            var result = mouses.Select(m =>
            {
                // Parse IDs for assigned, user history, and set history
                var assignedIds = m.assigned?.Split(',')
                    .Select(id => int.TryParse(id.Trim(), out var result) ? result : (int?)null)
                    .Where(id => id.HasValue)
                    .Select(id => id.Value)
                    .ToList();

                var userHistoryIds = m.user_history?.Split(',')
                    .Select(id => int.TryParse(id.Trim(), out var result) ? result : (int?)null)
                    .Where(id => id.HasValue)
                    .Select(id => id.Value)
                    .ToList();

                var setHistoryIds = m.set_history?.Split(',')
                    .Select(id => int.TryParse(id.Trim(), out var result) ? result : (int?)null)
                    .Where(id => id.HasValue)
                    .Select(id => id.Value)
                    .ToList();

                return new AVRWithIds
                {
                    id = m.id,
                    model = m.model,                    
                    color = m.color,
                    brand = m.brand,
                    status = m.status,
                    assigned = m.assigned,
                    user_history = m.user_history,
                    set_history = m.set_history,
                    li_description = m.li_description,
                    acquired_date = m.acquired_date,
                    asset_barcode = m.asset_barcode,
                    serial_no = m.serial_no,
                    date_created = m.date_created,
                    date_updated = m.date_updated,

                    // Populate Assigned Users
                    Assigned = users
                        .Where(u => assignedIds != null && assignedIds.Contains(u.id))
                        .Select(u => new UserDto
                        {
                            id = u.id,
                            first_name = u.first_name,
                            middle_name = u.middle_name,
                            last_name = u.last_name,
                            emp_id = u.emp_id,
                            contact_no = u.contact_no,
                            position = u.position,
                            dept_name = u.dept_name,
                            company_name = u.company_name,
                            date_created = u.date_created,
                            date_updated = u.date_updated,
                        }).ToList(),

                    // Populate User History with Repeated Entries
                    UserHistory = userHistoryIds != null
                        ? userHistoryIds.Select(id =>
                        {
                            var user = users.FirstOrDefault(u => u.id == id);
                            return user != null
                                ? new UserDto
                                {
                                    id = user.id,
                                    first_name = user.first_name,
                                    last_name = user.last_name,
                                    emp_id = user.emp_id,
                                    position = user.position
                                }
                                : null; // Return null if no match found
                        }).Where(x => x != null).ToList() // Filter out nulls
                        : new List<UserDto>(),

                    // Populate Set History with Repeated Entries
                    SetHistory = setHistoryIds != null
                        ? setHistoryIds.Select(id =>
                        {
                            var desktop = desktops.FirstOrDefault(d => d.id == id);
                            return desktop != null
                                ? new DesktopDto
                                {
                                    id = desktop.id,
                                    model = desktop.model,
                                    color = desktop.color,
                                    brand = desktop.brand,
                                    processor = desktop.processor,
                                    asset_barcode = desktop.asset_barcode,
                                    li_description = desktop.li_description,
                                    ram = desktop.ram,
                                    date_created = desktop.date_created,
                                    date_updated = desktop.date_updated,
                                }
                                : null; // Return null if no match found
                        }).Where(x => x != null).ToList() // Filter out nulls
                        : new List<DesktopDto>(),
                };
            }).ToList();

            // Return the result as a response
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AVRDto>> GetDesktopById(int id)
        {
            // Retrieve the desktop by ID
            var data = await _context.AVRs.FirstOrDefaultAsync(d => d.id == id);

            if (data == null)
            {
                return NotFound($"Desktop with ID {id} not found.");
            }

            // Retrieve all users (optional optimization: limit query to required IDs)
            var users = await _context.Users.ToListAsync();

            // Parse IDs for assigned and user history
            var assignedIds = data.assigned?.Split(',')
                .Select(x => int.TryParse(x.Trim(), out var result) ? result : (int?)null)
                .Where(id => id.HasValue)
                .Select(id => id.Value)
                .ToList();

            var userHistoryIds = data.user_history?.Split(',')
                .Select(x => int.TryParse(x.Trim(), out var result) ? result : (int?)null)
                .Where(id => id.HasValue)
                .Select(id => id.Value)
                .ToList();

            // Map to DesktopDto
            var result = new MouseWithIds
            {
                id = data.id,
                model = data.model,
                //size = m.size,
                color = data.color,
                brand = data.brand,
                status = data.status,
                assigned = data.assigned,
                user_history = data.user_history,
                set_history = data.set_history,
                li_description = data.li_description,
                acquired_date = data.acquired_date,
                asset_barcode = data.asset_barcode,
                serial_no = data.serial_no,
                date_created = data.date_created,
                date_updated = data.date_updated,

                // Populate Assigned Users
                Assigned = users
                    .Where(u => assignedIds != null && assignedIds.Contains(u.id))
                    .Select(u => new UserDto
                    {
                        id = u.id,
                        first_name = u.first_name,
                        middle_name = u.middle_name,
                        last_name = u.last_name,
                        emp_id = u.emp_id,
                        contact_no = u.contact_no,
                        position = u.position,
                        dept_name = u.dept_name,
                        company_name = u.company_name,
                        date_created = u.date_created,
                        date_updated = u.date_updated,
                    }).ToList(),

                // Populate User History with Repeated Entries
                UserHistory = userHistoryIds != null
                    ? userHistoryIds.Select(id =>
                    {
                        var user = users.FirstOrDefault(u => u.id == id);
                        return user != null
                            ? new UserDto
                            {
                                id = user.id,
                                first_name = user.first_name,
                                last_name = user.last_name,
                                emp_id = user.emp_id,
                                position = user.position
                            }
                            : null; // Return null if no match found
                    }).Where(x => x != null).ToList() // Filter out nulls
                    : new List<UserDto>(),
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<AVR>>> CreateAVR( AVRDto dto)
        {       

            var avr = new AVR
            {
                model = dto.model,
                color = dto.color,
                brand = dto.brand,
                status = "Active",
                assigned = "",
                user_history = "",
                set_history = "",
                li_description = $"{dto.model} {dto.color} {dto.brand}",
                acquired_date = dto.acquired_date,
                asset_barcode = dto.asset_barcode,
                serial_no = dto.serial_no,
            };
            _context.AVRs.Add(avr);
            await _context.SaveChangesAsync();

            return Ok(await _context.AVRs.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<AVR>>> UpdateAVR(int id, AVRDto dto)
        {

            // Find the existing AVR entity by ID
            var avr = await _context.AVRs.FindAsync(id);
            if (avr == null)
            {
                return NotFound($"No AVR found with ID {id}.");
            }

            // Update the AVR properties
            avr.model = dto.model;
            avr.color = dto.color;
            avr.brand = dto.brand;
            avr.status = dto.status;
            avr.assigned = dto.assigned;
            avr.user_history = dto.user_history;
            avr.set_history = dto.set_history;
            avr.li_description = dto.li_description;
            avr.acquired_date = dto.acquired_date;
            avr.asset_barcode = dto.asset_barcode;
            avr.serial_no = dto.serial_no;

            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.AVRs.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<AVR>>> DeleteAVR(int id)
        {
            // Find the existing AVR entity by ID
            var avr = await _context.AVRs.FindAsync(id);
            if (avr == null)
            {
                return NotFound($"No AVR found with ID {id}.");
            }

            // Remove the AVR from the database
            _context.AVRs.Remove(avr);
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.AVRs.ToListAsync());
        }

    }
}

