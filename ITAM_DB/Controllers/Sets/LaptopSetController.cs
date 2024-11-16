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
                    status = ds.status,
                    acquired_date  = ds.acquired_date,
                    li_description = ds.li_description,

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
                externalDrive_id = dto.externalDrive_id,
                user_id = dto.user_id,
                assigned = $"{dto.user_id}",
                status = "Active",
                li_description = "N/A",
                acquired_date = dto.acquired_date,
            };

            try
            {
                // Add and save to generate ID
                _context.LaptopSets.Add(set);
                await _context.SaveChangesAsync();

                // Parse IDs according to their actual type (assuming integers)
                int laptopId = int.Parse(dto.laptop_id);
                int dongleId = int.Parse(dto.dongle_id);
                int keyboardId = int.Parse(dto.keyboard_id);
                int lanAdapterId = int.Parse(dto.lanAdapter_id);
                int monitorId = int.Parse(dto.monitor_id);
                int mouseId = int.Parse(dto.mouse_id);
                int webcamId = int.Parse(dto.webcam_id);
                int bagId = int.Parse(dto.bag_id);
                int externalDriveId = int.Parse(dto.externalDrive_id);

                // Laptop update
                var laptop = await _context.Laptops.FirstOrDefaultAsync(l => l.id == laptopId);
                if (laptop == null) return NotFound("Laptop with the specified laptop_id not found.");

                if (!string.IsNullOrEmpty(dto.user_id))
                {
                    var userIds = laptop.user_history
                        .Split(',')
                        .Select(id => id.Trim())
                        .Where(id => id != "0" && !string.IsNullOrEmpty(id))
                        .ToList();

                    if (!userIds.Contains(dto.user_id)) userIds.Add(dto.user_id);
                    laptop.user_history = string.Join(", ", userIds);
                }

                laptop.assigned = set.id.ToString();
                var phTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Manila");
                laptop.date_updated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);

                // Dongle update
                var dongle = await _context.Dongles.FirstOrDefaultAsync(d => d.id == dongleId);
                if (dongle != null)
                {
                    var setHistory = dongle.set_history
                        .Split(',')
                        .Select(id => id.Trim())
                        .Where(id => !string.IsNullOrEmpty(id))
                        .ToList();
                    setHistory.Add(dto.laptop_id);
                    dongle.set_history = string.Join(", ", setHistory);

                    //var userHistory = dongle.user_history
                    //    .Split(',')
                    //    .Select(id => id.Trim())
                    //    .Where(id => !string.IsNullOrEmpty(id))
                    //    .ToList();
                    //if (!userHistory.Contains(dto.user_id)) userHistory.Add(dto.user_id);
                    //dongle.user_history = string.Join(", ", userHistory);
                    var userHistory = dongle.user_history
                      .Split(',')
                      .Select(id => id.Trim())
                      .Where(id => !string.IsNullOrEmpty(id))
                      .ToList();
                    userHistory.Add(dto.user_id);
                    dongle.user_history = string.Join(", ", userHistory);
                    dongle.date_updated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);

                    _context.Dongles.Update(dongle);
                    await _context.SaveChangesAsync();
                }

                // Keyboard update
                var keyboard = await _context.Keyboards.FirstOrDefaultAsync(k => k.id == keyboardId);
                if (keyboard != null)
                {
                    var setHistory = keyboard.set_history
                        .Split(',')
                        .Select(id => id.Trim())
                        .Where(id => !string.IsNullOrEmpty(id))
                        .ToList();
                    setHistory.Add(dto.laptop_id);
                    keyboard.set_history = string.Join(", ", setHistory);

                    var userHistory = keyboard.user_history
                      .Split(',')
                      .Select(id => id.Trim())
                      .Where(id => !string.IsNullOrEmpty(id))
                      .ToList();
                    userHistory.Add(dto.user_id);
                    keyboard.user_history = string.Join(", ", userHistory);
                    keyboard.date_updated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);

                    _context.Keyboards.Update(keyboard);
                    await _context.SaveChangesAsync();
                }

                // Lan Adapter update
                var lanadapter = await _context.LanAdapters.FirstOrDefaultAsync(l => l.id == lanAdapterId);
                if (lanadapter != null)
                {
                    var setHistory = lanadapter.set_history
                        .Split(',')
                        .Select(id => id.Trim())
                        .Where(id => !string.IsNullOrEmpty(id))
                        .ToList();
                    setHistory.Add(dto.lanAdapter_id);
                    lanadapter.set_history = string.Join(", ", setHistory);

                    var userHistory = lanadapter.user_history
                      .Split(',')
                      .Select(id => id.Trim())
                      .Where(id => !string.IsNullOrEmpty(id))
                      .ToList();
                    userHistory.Add(dto.user_id);
                    lanadapter.user_history = string.Join(", ", userHistory);
                    lanadapter.date_updated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);

                    _context.LanAdapters.Update(lanadapter);
                    await _context.SaveChangesAsync();
                }

                // Monitor update
                var monitor = await _context.Monitors.FirstOrDefaultAsync(m => m.id == monitorId);
                if (monitor != null)
                {
                    var setHistory = monitor.set_history
                        .Split(',')
                        .Select(id => id.Trim())
                        .Where(id => !string.IsNullOrEmpty(id))
                        .ToList();
                    setHistory.Add(dto.monitor_id);
                    monitor.set_history = string.Join(", ", setHistory);

                    var userHistory = monitor.user_history
                      .Split(',')
                      .Select(id => id.Trim())
                      .Where(id => !string.IsNullOrEmpty(id))
                      .ToList();
                    userHistory.Add(dto.user_id);
                    monitor.user_history = string.Join(", ", userHistory);
                    monitor.date_updated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);

                    _context.Monitors.Update(monitor);
                    await _context.SaveChangesAsync();
                }

                // Mouse update
                var mouse = await _context.Mouses.FirstOrDefaultAsync(m => m.id == mouseId);
                if (mouse != null)
                {
                    var setHistory = mouse.set_history
                        .Split(',')
                        .Select(id => id.Trim())
                        .Where(id => !string.IsNullOrEmpty(id))
                        .ToList();
                    setHistory.Add(dto.mouse_id);
                    mouse.set_history = string.Join(", ", setHistory);

                    var userHistory = mouse.user_history
                        .Split(',')
                        .Select(id => id.Trim())
                        .Where(id => !string.IsNullOrEmpty(id))
                        .ToList();
                    userHistory.Add(dto.user_id);
                    mouse.user_history = string.Join(", ", userHistory);
                    mouse.date_updated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);

                    _context.Mouses.Update(mouse);
                    await _context.SaveChangesAsync();
                }

                // WebCam update
                var webcam = await _context.WebCams.FirstOrDefaultAsync(w => w.id == webcamId);
                if (webcam != null)
                {
                    var setHistory = webcam.set_history
                        .Split(',')
                        .Select(id => id.Trim())
                        .Where(id => !string.IsNullOrEmpty(id))
                        .ToList();
                    setHistory.Add(dto.webcam_id);
                    webcam.set_history = string.Join(", ", setHistory);

                    var userHistory = webcam.user_history
                         .Split(',')
                         .Select(id => id.Trim())
                         .Where(id => !string.IsNullOrEmpty(id))
                         .ToList();
                    userHistory.Add(dto.user_id);
                    webcam.user_history = string.Join(", ", userHistory);
                    webcam.date_updated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);

                    _context.WebCams.Update(webcam);
                    await _context.SaveChangesAsync();
                }

                // Bag update
                var bag = await _context.Bags.FirstOrDefaultAsync(b => b.id == bagId);
                if (bag != null)
                {
                    var setHistory = bag.set_history
                        .Split(',')
                        .Select(id => id.Trim())
                        .Where(id => !string.IsNullOrEmpty(id))
                        .ToList();
                    setHistory.Add(dto.bag_id);
                    bag.set_history = string.Join(", ", setHistory);

                    var userHistory = bag.user_history
                         .Split(',')
                         .Select(id => id.Trim())
                         .Where(id => !string.IsNullOrEmpty(id))
                         .ToList();
                    userHistory.Add(dto.user_id);
                    bag.user_history = string.Join(", ", userHistory);
                    bag.date_updated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);

                    _context.Bags.Update(bag);
                    await _context.SaveChangesAsync();
                }

                // ExternalDrive update
                var externaldrive = await _context.ExternalDrives.FirstOrDefaultAsync(e => e.id == externalDriveId);
                if (externaldrive != null)
                {
                    var setHistory = externaldrive.set_history
                        .Split(',')
                        .Select(id => id.Trim())
                        .Where(id => !string.IsNullOrEmpty(id))
                        .ToList();
                    setHistory.Add(dto.externalDrive_id);
                    externaldrive.set_history = string.Join(", ", setHistory);

                    var userHistory = externaldrive.user_history
                         .Split(',')
                         .Select(id => id.Trim())
                         .Where(id => !string.IsNullOrEmpty(id))
                         .ToList();
                    userHistory.Add(dto.user_id);
                    externaldrive.user_history = string.Join(", ", userHistory);
                    externaldrive.date_updated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);

                    _context.ExternalDrives.Update(externaldrive);
                    await _context.SaveChangesAsync();
                }

                // Final save
                _context.Laptops.Update(laptop);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error occurred: {ex.Message}");
                Console.Error.WriteLine(ex.StackTrace);
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

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
            set.acquired_date = dto.acquired_date;                       
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
