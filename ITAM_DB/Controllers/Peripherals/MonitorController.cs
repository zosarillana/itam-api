using ITAM_API.Data;
using ITAM_DB.Data.Peripherals;
using ITAM_DB.Dto.Computers.Desktop;
using ITAM_DB.Dto.Peripherals.Monitor;
using ITAM_DB.Dto.User;
using ITAM_DB.Model.Peripherals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design.Serialization;
using System.Runtime.Intrinsics.X86;

namespace ITAM_DB.Controllers.Peripherals
{

    [ApiController]
    [Route("[controller]")]
    public class MonitorController : Controller
    {
        private readonly ItotContext _context;
        public MonitorController(ItotContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MonitorWithIds>>> GetAllMonitor()
        {
            // Fetch all necessary data from the database
            var monitors = await _context.Monitors.ToListAsync();
            var users = await _context.Users.ToListAsync();
            var desktops = await _context.Desktops.ToListAsync();

            // Map the monitors to their DTO representation
            var result = monitors.Select(m =>
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

                return new MonitorWithIds
                {
                    id = m.id,
                    model = m.model,
                    size = m.size,
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
        public async Task<ActionResult<MonitorWithIds>> GetMonitorById(int id)
        {
            // Fetch the monitor by ID
            var monitor = await _context.Monitors.FindAsync(id);

            if (monitor == null)
            {
                return NotFound();
            }

            // Fetch all necessary data from the database
            var users = await _context.Users.ToListAsync();
            var desktops = await _context.Desktops.ToListAsync();

            // Parse IDs for assigned, user history, and set history
            var assignedIds = monitor.assigned?.Split(',')
                .Select(id => int.TryParse(id.Trim(), out var result) ? result : (int?)null)
                .Where(id => id.HasValue)
                .Select(id => id.Value)
                .ToList();

            var userHistoryIds = monitor.user_history?.Split(',')
                .Select(id => int.TryParse(id.Trim(), out var result) ? result : (int?)null)
                .Where(id => id.HasValue)
                .Select(id => id.Value)
                .ToList();

            var setHistoryIds = monitor.set_history?.Split(',')
                .Select(id => int.TryParse(id.Trim(), out var result) ? result : (int?)null)
                .Where(id => id.HasValue)
                .Select(id => id.Value)
                .ToList();

            // Map the monitor to its DTO representation
            var monitorDto = new MonitorWithIds
            {
                id = monitor.id,
                model = monitor.model,
                size = monitor.size,
                color = monitor.color,
                brand = monitor.brand,
                status = monitor.status,
                assigned = monitor.assigned,
                user_history = monitor.user_history,
                set_history = monitor.set_history,
                li_description = monitor.li_description,
                acquired_date = monitor.acquired_date,
                asset_barcode = monitor.asset_barcode,
                serial_no = monitor.serial_no,
                date_created = monitor.date_created,
                date_updated = monitor.date_updated,

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
                                ram = desktop.ram,
                                li_description = desktop.li_description,                                
                                date_created = desktop.date_created,
                                date_updated = desktop.date_updated,
                            }
                            : null; // Return null if no match found
                    }).Where(x => x != null).ToList() // Filter out nulls
                    : new List<DesktopDto>(),
            };

            // Return the result as a response
            return Ok(monitorDto);
        }


        [HttpPost]
        public async Task<ActionResult<List<ITAM_DB.Model.Peripherals.Monitor>>> CreateMonitor(MonitorDto dto)
        {

            var monitor = new ITAM_DB.Model.Peripherals.Monitor
            {
                size = dto.size,
                model = dto.model,
                color = dto.color,
                brand = dto.brand,
                status = "Active",
                assigned = "",
                user_history = "",
                set_history = "",
                li_description = $"{dto.model} {dto.color} {dto.brand} {dto.size}",
                acquired_date = dto.acquired_date,
                asset_barcode = dto.asset_barcode,
                serial_no = dto.serial_no,
            };

            _context.Monitors.Add(monitor);  // Use the local variable 'monitor' here
            await _context.SaveChangesAsync();

            return Ok(await _context.Monitors.ToListAsync());
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<ITAM_DB.Model.Peripherals.Monitor>>> UpdateMonitor(int id, MonitorDto dto)
        {           

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
            monitor.status = dto.status;
            monitor.user_history = dto.user_history;
            monitor.set_history = dto.set_history;
            monitor.assigned = dto.assigned;
            monitor.li_description = dto.li_description;
            monitor.acquired_date = dto.acquired_date;
            monitor.asset_barcode = dto.asset_barcode;
            monitor.serial_no = dto.serial_no;

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

