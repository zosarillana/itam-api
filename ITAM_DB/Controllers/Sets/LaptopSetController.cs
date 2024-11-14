using ITAM_API.Data;
using ITAM_DB.Dto.Computers;
using ITAM_DB.Dto.Peripherals;
using ITAM_DB.Dto.Sets;
using ITAM_DB.Dto.User;
using ITAM_DB.Model.Sets;
using ITAM_DB.Model.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserModel = ITAM_DB.Model.User.User;

namespace ITAM_DB.Controllers.Sets
{
    [ApiController]
    [Route("[controller]")]
    public class LaptopSetController : Controller
    {
        private readonly ItotContext _context;
        public LaptopSetController(ItotContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<LaptopDto>>> GetAllDesktopSets()
        {
            // Fetch all necessary data from the database
            var laptopsets = await _context.LaptopSets.ToListAsync();
            var laptops = await _context.Laptops.ToListAsync();            
            var dongles = await _context.Dongles.ToListAsync();
            var keyboards = await _context.Keyboards.ToListAsync();
            var lanadapters = await _context.LanAdapters.ToListAsync();
            var monitors = await _context.Monitors.ToListAsync();
            var mouses = await _context.Mouses.ToListAsync();           
            var webcams = await _context.WebCams.ToListAsync();
            var bags = await _context.Bags.ToListAsync();
            var externaldrives = await _context.ExternalDrives.ToListAsync();
            var users = await _context.Users.ToListAsync();

            var result = laptopsets.Select(ds =>
            {
                // Parse IDs for peripherals                
                var laptopsIds = ds.laptop_id?.Split(',').Select(id => int.TryParse(id, out var result) ? result : (int?)null).Where(id => id.HasValue).Select(id => id.Value).ToList();
                var dongleIds = ds.dongle_id?.Split(',').Select(id => int.TryParse(id, out var result) ? result : (int?)null).Where(id => id.HasValue).Select(id => id.Value).ToList();
                var keyboardIds = ds.keyboard_id?.Split(',').Select(id => int.TryParse(id, out var result) ? result : (int?)null).Where(id => id.HasValue).Select(id => id.Value).ToList();
                var lanIds = ds.lanAdapter_id?.Split(',').Select(id => int.TryParse(id, out var result) ? result : (int?)null).Where(id => id.HasValue).Select(id => id.Value).ToList();
                var monitorIds = ds.monitor_id?.Split(',').Select(id => int.TryParse(id, out var result) ? result : (int?)null).Where(id => id.HasValue).Select(id => id.Value).ToList();
                var mouseIds = ds.mouse_id?.Split(',').Select(id => int.TryParse(id, out var result) ? result : (int?)null).Where(id => id.HasValue).Select(id => id.Value).ToList();
                var bagIds = ds.bag_id?.Split(',').Select(id => int.TryParse(id, out var result) ? result : (int?)null).Where(id => id.HasValue).Select(id => id.Value).ToList();                
                var externaldriveIds = ds.externalDrive_id?.Split(',').Select(id => int.TryParse(id, out var result) ? result : (int?)null).Where(id => id.HasValue).Select(id => id.Value).ToList();
                var webcamIds = ds.webcam_id?.Split(',').Select(id => int.TryParse(id, out var result) ? result : (int?)null).Where(id => id.HasValue).Select(id => id.Value).ToList();                
                var userIds = ds.webcam_id?.Split(',').Select(id => int.TryParse(id, out var result) ? result : (int?)null).Where(id => id.HasValue).Select(id => id.Value).ToList();

                return new LaptopSetDto
                {
                    id = ds.id,
                    laptop_id = ds.laptop_id,
                    dongle_id = ds.dongle_id,
                    keyboard_id = ds.keyboard_id,
                    lanAdapter_id = ds.lanAdapter_id,
                    monitor_id = ds.monitor_id,
                    mouse_id = ds.mouse_id,
                    webcam_id = ds.webcam_id,
                    bag_id = ds.bag_id,
                    externalDrive_id = ds.externalDrive_id,
                    user_id = ds.user_id,
                    assigned = ds.assigned,

                    Laptops = laptops
                    .Where(laptop => laptopsIds != null && laptopsIds.Contains(laptop.id))
                    .Select(laptop => new LaptopDto // Use LaptopDto instead of DesktopDto
                    {
                        id = laptop.id,
                        model = laptop.model,
                        color = laptop.color,
                        brand = laptop.brand,
                        status = laptop.status,
                        assigned = laptop.assigned,
                        user_history = laptop.user_history,
                        li_description = laptop.li_description,
                        acquired_date = laptop.acquired_date,
                        asset_barcode = laptop.asset_barcode,
                        serial_no = laptop.serial_no,
                    }).ToList(),

                    Dongles = dongles
                        .Where(dongle => dongleIds != null && dongleIds.Contains(dongle.id))
                        .Select(dongle => new DongleDto
                        {
                            id = dongle.id,
                            model = dongle.model,
                            color = dongle.color,
                            brand = dongle.brand,
                            type = dongle.type,
                            status = dongle.status,
                            assigned = dongle.assigned,
                            user_history = dongle.user_history,
                            set_history = dongle.set_history,
                            li_description = dongle.li_description,
                            acquired_date = dongle.acquired_date,
                            asset_barcode = dongle.asset_barcode,
                            serial_no = dongle.serial_no,
                        }).ToList(),

                    Keyboards = keyboards
                        .Where(keyboard => keyboardIds != null && keyboardIds.Contains(keyboard.id))
                        .Select(keyboard => new KeyboardDto
                        {
                            id = keyboard.id,
                            model = keyboard.model,
                            color = keyboard.color,
                            brand = keyboard.brand,
                            type = keyboard.type,
                            status = keyboard.status,
                            assigned = keyboard.assigned,
                            user_history = keyboard.user_history,
                            set_history = keyboard.set_history,
                            li_description = keyboard.li_description,
                            acquired_date = keyboard.acquired_date,
                            asset_barcode = keyboard.asset_barcode,
                            serial_no = keyboard.serial_no,
                        }).ToList(),

                    LanAdapters = lanadapters
                        .Where(lan => lanIds != null && lanIds.Contains(lan.id))
                        .Select(lan => new LanAdapterDto
                        {
                            id = lan.id,
                            model = lan.model,
                            color = lan.color,
                            brand = lan.brand,
                            type = lan.type,
                            status = lan.status,
                            assigned = lan.assigned,
                            user_history = lan.user_history,
                            set_history = lan.set_history,
                            li_description = lan.li_description,
                            acquired_date = lan.acquired_date,
                            asset_barcode = lan.asset_barcode,
                            serial_no = lan.serial_no,
                        }).ToList(),

                    Monitors = monitors
                        .Where(monitor => monitorIds != null && monitorIds.Contains(monitor.id))
                        .Select(monitor => new MonitorDto
                        {
                            id = monitor.id,
                            model = monitor.model,
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
                        }).ToList(),

                    Mouses = mouses
                        .Where(mouse => mouseIds != null && mouseIds.Contains(mouse.id))
                        .Select(mouse => new MouseDto
                        {
                            id = mouse.id,
                            model = mouse.model,
                            color = mouse.color,
                            brand = mouse.brand,
                            status = mouse.status,
                            type = mouse.type,
                            assigned = mouse.assigned,
                            user_history = mouse.user_history,
                            set_history = mouse.set_history,
                            li_description = mouse.li_description,
                            acquired_date = mouse.acquired_date,
                            asset_barcode = mouse.asset_barcode,
                            serial_no = mouse.serial_no,
                        }).ToList(),                

                    WebCams = webcams
                        .Where(webcam => webcamIds != null && webcamIds.Contains(webcam.id))
                        .Select(webcam => new WebCamDto
                        {
                            id = webcam.id,
                            model = webcam.model,
                            color = webcam.color,
                            brand = webcam.brand,
                            status = webcam.status,
                            assigned = webcam.assigned,
                            user_history = webcam.user_history,
                            set_history = webcam.set_history,
                            li_description = webcam.li_description,
                            acquired_date = webcam.acquired_date,
                            asset_barcode = webcam.asset_barcode,
                            serial_no = webcam.serial_no,
                        }).ToList(),

                    Bags = bags
                        .Where(bags => bagIds != null && bagIds.Contains(bags.id))
                        .Select(bags => new BagDto
                        {
                            id = bags.id,                            
                            color = bags.color,
                            brand = bags.brand,
                            status = bags.status,
                            assigned = bags.assigned,
                            user_history = bags.user_history,
                            set_history = bags.set_history,
                            li_description = bags.li_description,
                            acquired_date = bags.acquired_date,
                            asset_barcode = bags.asset_barcode,
                            serial_no = bags.serial_no,
                        }).ToList(),

                    ExternalDrives = externaldrives
                        .Where(externaldrives => externaldriveIds != null && externaldriveIds.Contains(externaldrives.id))
                        .Select(externaldrives => new ExternalDriveDto
                        {
                            id = externaldrives.id,
                            color = externaldrives.color,                            
                            status = externaldrives.status,
                            type = externaldrives.type,
                            user_history = externaldrives.user_history,
                            set_history = externaldrives.set_history,
                            li_description = externaldrives.li_description,
                            acquired_date = externaldrives.acquired_date,
                            asset_barcode = externaldrives.asset_barcode,
                            serial_no = externaldrives.serial_no,
                        }).ToList(),

                    Users = users
                        .Where(users => userIds != null && userIds.Contains(users.id))
                        .Select(users => new UserModel
                        {
                            id = users.id,
                            first_name = users.first_name,
                            middle_name = users.middle_name,
                            last_name = users.last_name,
                            emp_id = users.emp_id,
                            contact_no = users.contact_no,
                            position = users.position,
                            dept_name = users.dept_name,
                            company_name = users.company_name,                           
                        }).ToList(),

                };
            }).ToList();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<LaptopSet>>> CreateLaptop(LaptopSetDto dto)
        {
            if (dto == null)
            {
                return BadRequest("LaptopSet Data is Required.");
            }

            // Create a new LaptopSet object based on the provided dto
            var set = new LaptopSet
            {
                laptop_id = dto.laptop_id,
                dongle_id = dto.dongle_id,
                keyboard_id = dto.keyboard_id,
                lanAdapter_id = dto.lanAdapter_id,
                monitor_id = dto.monitor_id,
                mouse_id = dto.mouse_id,
                webcam_id = dto.webcam_id,
                bag_id = dto.bag_id,
                externalDrive_id = dto.externalDrive_id, // Corrected field assignment
                user_id = dto.user_id,
                status = dto.status,
                li_description = dto.li_description,
                acquired_date = dto.acquired_date,
            };

            try
            {
                // Add the new LaptopSet to the database context and save changes
                _context.LaptopSets.Add(set);
                await _context.SaveChangesAsync(); // Save here to generate an ID for set

                // Find the corresponding Laptop using laptop_id from dto
                var laptop = await _context.Laptops.FirstOrDefaultAsync(l => l.id.ToString() == dto.laptop_id);
                if (laptop == null)
                {
                    // If Laptop not found, return a 404 response
                    return NotFound("Laptop with the specified laptop_id not found.");
                }

                // Update the Laptop's user_history to include the new user_id
                if (!string.IsNullOrEmpty(dto.user_id))
                {
                    // Split user_history and filter out "0" if it exists
                    var userIds = laptop.user_history
                        .Split(',')
                        .Select(id => id.Trim())
                        .Where(id => id != "0" && !string.IsNullOrEmpty(id)) // Remove "0" and any empty entries
                        .ToList();

                    // Add new user_id, but only if it's not already present
                    if (!userIds.Contains(dto.user_id))
                    {
                        userIds.Add(dto.user_id); // Add the new user ID without duplicates
                    }

                    // Update user_history with the new list of user IDs
                    laptop.user_history = string.Join(", ", userIds);
                }

                // Update the Laptop's assigned field
                laptop.assigned = set.id.ToString(); // Set assigned to the new LaptopSet's ID

                // Update the date_updated field for Laptop
                var phTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Manila");
                laptop.date_updated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);

                // Find and update the corresponding Dongle model
                var dongle = await _context.Dongles.FirstOrDefaultAsync(d => d.id.ToString() == dto.dongle_id);
                if (dongle != null)
                {
                    // Update Dongle's set_history with laptop_id
                    var setHistory = dongle.set_history
                        .Split(',')
                        .Select(id => id.Trim())
                        .Where(id => !string.IsNullOrEmpty(id)) // Remove any empty entries
                        .ToList();

                    setHistory.Add(dto.laptop_id); // Add the new laptop_id to the set_history
                    dongle.set_history = string.Join(", ", setHistory); // Update the set_history

                    // Update Dongle's user_history with the user_id
                    var userHistory = dongle.user_history
                        .Split(',')
                        .Select(id => id.Trim())
                        .Where(id => !string.IsNullOrEmpty(id)) // Remove any empty entries
                        .ToList();

                    // Add new user_id to user_history, but only if it's not already present
                    if (!userHistory.Contains(dto.user_id))
                    {
                        userHistory.Add(dto.user_id); // Add the new user_id to user_history
                    }

                    dongle.user_history = string.Join(", ", userHistory); // Update the user_history

                    // Update the date_updated field for Dongle
                    dongle.date_updated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);

                    // Save changes for Dongle
                    _context.Dongles.Update(dongle);
                    await _context.SaveChangesAsync();
                }

                // Find and update the corresponding Dongle model
                var keyboard = await _context.Keyboards.FirstOrDefaultAsync(k => k.id.ToString() == dto.keyboard_id);
                if (keyboard != null)
                {
                    // Update Dongle's set_history with laptop_id
                    var setHistory = keyboard.set_history
                        .Split(',')
                        .Select(id => id.Trim())
                        .Where(id => !string.IsNullOrEmpty(id)) // Remove any empty entries
                        .ToList();

                    setHistory.Add(dto.laptop_id); // Add the new laptop_id to the set_history
                    keyboard.set_history = string.Join(", ", setHistory); // Update the set_history

                    // Update Dongle's user_history with the user_id
                    var userHistory = keyboard.user_history
                        .Split(',')
                        .Select(id => id.Trim())
                        .Where(id => !string.IsNullOrEmpty(id)) // Remove any empty entries
                        .ToList();

                    // Add new user_id to user_history, but only if it's not already present
                    if (!userHistory.Contains(dto.user_id))
                    {
                        userHistory.Add(dto.user_id); // Add the new user_id to user_history
                    }

                    keyboard.user_history = string.Join(", ", userHistory); // Update the user_history

                    // Update the date_updated field for Dongle
                    keyboard.date_updated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);

                    // Save changes for Dongle
                    _context.Keyboards.Update(keyboard);
                    await _context.SaveChangesAsync();
                }

                // Find and update the corresponding Dongle model
                var lanadapter = await _context.LanAdapters.FirstOrDefaultAsync(l => l.id.ToString() == dto.lanAdapter_id);
                if (lanadapter != null)
                {
                    // Update Dongle's set_history with laptop_id
                    var setHistory = lanadapter.set_history
                        .Split(',')
                        .Select(id => id.Trim())
                        .Where(id => !string.IsNullOrEmpty(id)) // Remove any empty entries
                        .ToList();

                    setHistory.Add(dto.lanAdapter_id); // Add the new laptop_id to the set_history
                    lanadapter.set_history = string.Join(", ", setHistory); // Update the set_history

                    // Update Dongle's user_history with the user_id
                    var userHistory = lanadapter.user_history
                        .Split(',')
                        .Select(id => id.Trim())
                        .Where(id => !string.IsNullOrEmpty(id)) // Remove any empty entries
                        .ToList();

                    // Add new user_id to user_history, but only if it's not already present
                    if (!userHistory.Contains(dto.user_id))
                    {
                        userHistory.Add(dto.user_id); // Add the new user_id to user_history
                    }

                    lanadapter.user_history = string.Join(", ", userHistory); // Update the user_history

                    // Update the date_updated field for Dongle
                    lanadapter.date_updated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);

                    // Save changes for Dongle
                    _context.LanAdapters.Update(lanadapter);
                    await _context.SaveChangesAsync();
                }

                // Find and update the corresponding Dongle model
                var monitor = await _context.Monitors.FirstOrDefaultAsync(m => m.id.ToString() == dto.monitor_id);
                if (monitor != null)
                {
                    // Update Dongle's set_history with laptop_id
                    var setHistory = monitor.set_history
                        .Split(',')
                        .Select(id => id.Trim())
                        .Where(id => !string.IsNullOrEmpty(id)) // Remove any empty entries
                        .ToList();

                    setHistory.Add(dto.monitor_id); // Add the new laptop_id to the set_history
                    monitor.set_history = string.Join(", ", setHistory); // Update the set_history

                    // Update Dongle's user_history with the user_id
                    var userHistory = monitor.user_history
                        .Split(',')
                        .Select(id => id.Trim())
                        .Where(id => !string.IsNullOrEmpty(id)) // Remove any empty entries
                        .ToList();

                    // Add new user_id to user_history, but only if it's not already present
                    if (!userHistory.Contains(dto.monitor_id))
                    {
                        userHistory.Add(dto.monitor_id); // Add the new user_id to user_history
                    }

                    monitor.user_history = string.Join(", ", userHistory); // Update the user_history

                    // Update the date_updated field for Dongle
                    monitor.date_updated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);

                    // Save changes for Dongle
                    _context.Monitors.Update(monitor);
                    await _context.SaveChangesAsync();
                }

                // Find and update the corresponding Dongle model
                var mouse = await _context.Mouses.FirstOrDefaultAsync(m => m.id.ToString() == dto.mouse_id);
                if (mouse != null)
                {
                    // Update Dongle's set_history with laptop_id
                    var setHistory = mouse.set_history
                        .Split(',')
                        .Select(id => id.Trim())
                        .Where(id => !string.IsNullOrEmpty(id)) // Remove any empty entries
                        .ToList();

                    setHistory.Add(dto.mouse_id); // Add the new laptop_id to the set_history
                    mouse.set_history = string.Join(", ", setHistory); // Update the set_history

                    // Update Dongle's user_history with the user_id
                    var userHistory = mouse.user_history
                        .Split(',')
                        .Select(id => id.Trim())
                        .Where(id => !string.IsNullOrEmpty(id)) // Remove any empty entries
                        .ToList();

                    // Add new user_id to user_history, but only if it's not already present
                    if (!userHistory.Contains(dto.mouse_id))
                    {
                        userHistory.Add(dto.mouse_id); // Add the new user_id to user_history
                    }

                    mouse.user_history = string.Join(", ", userHistory); // Update the user_history

                    // Update the date_updated field for Dongle
                    mouse.date_updated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);

                    // Save changes for Dongle
                    _context.Mouses.Update(mouse);
                    await _context.SaveChangesAsync();
                }

                // Find and update the corresponding Dongle model
                var webcam = await _context.WebCams.FirstOrDefaultAsync(w => w.ToString() == dto.webcam_id);
                if (webcam != null)
                {
                    // Update Dongle's set_history with laptop_id
                    var setHistory = webcam.set_history
                        .Split(',')
                        .Select(id => id.Trim())
                        .Where(id => !string.IsNullOrEmpty(id)) // Remove any empty entries
                        .ToList();

                    setHistory.Add(dto.webcam_id); // Add the new laptop_id to the set_history
                    webcam.set_history = string.Join(", ", setHistory); // Update the set_history

                    // Update Dongle's user_history with the user_id
                    var userHistory = webcam.user_history
                        .Split(',')
                        .Select(id => id.Trim())
                        .Where(id => !string.IsNullOrEmpty(id)) // Remove any empty entries
                        .ToList();

                    // Add new user_id to user_history, but only if it's not already present
                    if (!userHistory.Contains(dto.mouse_id))
                    {
                        userHistory.Add(dto.mouse_id); // Add the new user_id to user_history
                    }

                    webcam.user_history = string.Join(", ", userHistory); // Update the user_history

                    // Update the date_updated field for Dongle
                    webcam.date_updated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);

                    // Save changes for Dongle
                    _context.WebCams.Update(webcam);
                    await _context.SaveChangesAsync();
                }

                // Find and update the corresponding Dongle model
                var bag = await _context.Bags.FirstOrDefaultAsync(b => b.ToString() == dto.bag_id);
                if (bag != null)
                {
                    // Update Dongle's set_history with laptop_id
                    var setHistory = bag.set_history
                        .Split(',')
                        .Select(id => id.Trim())
                        .Where(id => !string.IsNullOrEmpty(id)) // Remove any empty entries
                        .ToList();

                    setHistory.Add(dto.bag_id); // Add the new laptop_id to the set_history
                    bag.set_history = string.Join(", ", setHistory); // Update the set_history

                    // Update Dongle's user_history with the user_id
                    var userHistory = bag.user_history
                        .Split(',')
                        .Select(id => id.Trim())
                        .Where(id => !string.IsNullOrEmpty(id)) // Remove any empty entries
                        .ToList();

                    // Add new user_id to user_history, but only if it's not already present
                    if (!userHistory.Contains(dto.mouse_id))
                    {
                        userHistory.Add(dto.mouse_id); // Add the new user_id to user_history
                    }

                    bag.user_history = string.Join(", ", userHistory); // Update the user_history

                    // Update the date_updated field for Dongle
                    bag.date_updated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);

                    // Save changes for Dongle
                    _context.Bags.Update(bag);
                    await _context.SaveChangesAsync();
                }

                // Find and update the corresponding Dongle model
                var externaldrive = await _context.ExternalDrives.FirstOrDefaultAsync(e => e.ToString() == dto.externalDrive_id);
                if (externaldrive != null)
                {
                    // Update Dongle's set_history with laptop_id
                    var setHistory = externaldrive.set_history
                        .Split(',')
                        .Select(id => id.Trim())
                        .Where(id => !string.IsNullOrEmpty(id)) // Remove any empty entries
                        .ToList();

                    setHistory.Add(dto.externalDrive_id); // Add the new laptop_id to the set_history
                    externaldrive.set_history = string.Join(", ", setHistory); // Update the set_history

                    // Update Dongle's user_history with the user_id
                    var userHistory = externaldrive.user_history
                        .Split(',')
                        .Select(id => id.Trim())
                        .Where(id => !string.IsNullOrEmpty(id)) // Remove any empty entries
                        .ToList();

                    // Add new user_id to user_history, but only if it's not already present
                    if (!userHistory.Contains(dto.mouse_id))
                    {
                        userHistory.Add(dto.mouse_id); // Add the new user_id to user_history
                    }

                    externaldrive.user_history = string.Join(", ", userHistory); // Update the user_history

                    // Update the date_updated field for Dongle
                    externaldrive.date_updated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);

                    // Save changes for Dongle
                    _context.ExternalDrives.Update(externaldrive);
                    await _context.SaveChangesAsync();
                }

                // Update the Laptop in the database
                _context.Laptops.Update(laptop);
                await _context.SaveChangesAsync(); // Save changes to the Laptop
            }


            catch (Exception ex)
            {
                // Log the exception (could use a logging framework here)
                Console.Error.WriteLine($"Error occurred: {ex.Message}");
                return StatusCode(500, "An error occurred while processing the request.");
            }

            // Return the updated list of LaptopSets
            return Ok(await _context.LaptopSets.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<LaptopSet>>> UpdateLaptop(int id, LaptopSetDto dto)
        {
            if (dto == null)
            {
                return BadRequest("LaptopSet data is required.");
            }

            // Find the existing AVR entity by ID
            var set = await _context.LaptopSets.FindAsync(id);
            if (set == null)
            {
                return NotFound($"No LaptopSet found with ID {id}.");
            }

            // Update the AVR properties
            set.laptop_id = dto.laptop_id;
            set.dongle_id = dto.dongle_id;
            set.keyboard_id = dto.keyboard_id;
            set.lanAdapter_id = dto.lanAdapter_id;
            set.monitor_id = dto.monitor_id;
            set.mouse_id = dto.mouse_id;              
            set.webcam_id = dto.webcam_id;
            set.bag_id = dto.bag_id;
            set.externalDrive_id = dto.bag_id;
            set.user_id = dto.user_id;
            set.status = dto.status;
            set.li_description = dto.li_description;
            set.acquired_date = dto.acquired_date;

            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.LaptopSets.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<LaptopSet>>> DeleteLaptop(int id)
        {
            // Find the existing AVR entity by ID
            var lpt = await _context.LaptopSets.FindAsync(id);
            if (lpt == null)
            {
                return NotFound($"No AVR found with ID {id}.");
            }

            // Remove the AVR from the database
            _context.LaptopSets.Remove(lpt);
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.LaptopSets.ToListAsync());
        }
    }
}
