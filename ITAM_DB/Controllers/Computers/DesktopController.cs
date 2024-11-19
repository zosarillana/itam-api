using ITAM_API.Data;
using ITAM_DB.Data.Computers;
using ITAM_DB.Data.Peripherals;
using ITAM_DB.Dto.Computers.Desktop;
using ITAM_DB.Dto.Peripherals;
using ITAM_DB.Dto.Peripherals.Monitor;
using ITAM_DB.Dto.User;
using ITAM_DB.Model.Computers;
using ITAM_DB.Model.Peripherals;
using ITAM_DB.Model.Sets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.Intrinsics.Arm;
using System.Threading;

namespace ITAM_DB.Controllers.Computers
{
    [ApiController]
    [Route("[controller]")]
    public class DesktopController : Controller
    {
        private readonly ItotContext _context;
        public DesktopController(ItotContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Desktop>>> GetAllDesktop()
        {          
            var users = await _context.Users.ToListAsync();
            var desktops = await _context.Desktops.ToListAsync();

            // Map the monitors to their DTO representation
            var result = desktops.Select(m =>
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


                return new DesktopDto
                {
                    id = m.id,
                    model = m.model,                   
                    color = m.color,
                    processor = m.processor,
                    ram = m.ram,
                    graphics = m.graphics,
                    operating_system = m.operating_system,
                    brand = m.brand,
                    status = m.status,
                    assigned = m.assigned,
                    user_history = m.user_history,                   
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
                };
            }).ToList();

            // Return the result as a response
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DesktopDto>> GetDesktopById(int id)
        {
            // Retrieve the desktop by ID
            var desktop = await _context.Desktops.FirstOrDefaultAsync(d => d.id == id);

            if (desktop == null)
            {
                return NotFound($"Desktop with ID {id} not found.");
            }

            // Retrieve all users (optional optimization: limit query to required IDs)
            var users = await _context.Users.ToListAsync();

            // Parse IDs for assigned and user history
            var assignedIds = desktop.assigned?.Split(',')
                .Select(x => int.TryParse(x.Trim(), out var result) ? result : (int?)null)
                .Where(id => id.HasValue)
                .Select(id => id.Value)
                .ToList();

            var userHistoryIds = desktop.user_history?.Split(',')
                .Select(x => int.TryParse(x.Trim(), out var result) ? result : (int?)null)
                .Where(id => id.HasValue)
                .Select(id => id.Value)
                .ToList();

            // Map to DesktopDto
            var result = new DesktopDto
            {
                id = desktop.id,
                model = desktop.model,
                color = desktop.color,
                processor = desktop.processor,
                ram = desktop.ram,
                graphics = desktop.graphics,
                operating_system = desktop.operating_system,
                brand = desktop.brand,
                status = desktop.status,
                assigned = desktop.assigned,
                user_history = desktop.user_history,
                li_description = desktop.li_description,
                acquired_date = desktop.acquired_date,
                asset_barcode = desktop.asset_barcode,
                serial_no = desktop.serial_no,
                date_created = desktop.date_created,
                date_updated = desktop.date_updated,

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
        public async Task<ActionResult<List<Desktop>>> CreateDesktop(DesktopDto dto)
        {          

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
            status = "Active",
            assigned = "Not Assigned",
            user_history = "",
            li_description = $"{dto.brand} {dto.model} {dto.processor} {dto.ram} {dto.storage_capacity} {dto.storage_type} {dto.operating_system} {dto.graphics} {dto.color}",
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
