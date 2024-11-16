using ITAM_API.Data;
using ITAM_DB.Data.Computers;
using ITAM_DB.Data.Peripherals;
using ITAM_DB.Data.Sets;
using ITAM_DB.Dto.Computers;
using ITAM_DB.Dto.Peripherals;
using ITAM_DB.Dto.Sets;
using ITAM_DB.Model.Computers;
using ITAM_DB.Model.Peripherals;
using ITAM_DB.Model.Sets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace ITAM_DB.Controllers.Sets
{
    [ApiController]
    [Route("[controller]")]
    public class DesktopSetController : Controller
    {
        private readonly ItotContext _context;
        public DesktopSetController(ItotContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<DesktopDto>>> GetAllDesktopSets()
        {
            // Fetch all necessary data from the database
            var desktopsets = await _context.DesktopSets.ToListAsync();
            var desktops = await _context.Desktops.ToListAsync();
            var avrs = await _context.AVRs.ToListAsync();
            var dongles = await _context.Dongles.ToListAsync();
            var keyboards = await _context.Keyboards.ToListAsync();
            var lanadapters = await _context.LanAdapters.ToListAsync();
            var monitors = await _context.Monitors.ToListAsync();
            var mouses = await _context.Mouses.ToListAsync();
            var ups = await _context.UPSs.ToListAsync();
            var webcams = await _context.WebCams.ToListAsync();

            var result = desktopsets.Select(ds =>
            {
                // Parse IDs for peripherals
                var avrIds = ds.avr_id?.Split(',').Select(id => int.TryParse(id, out var result) ? result : (int?)null).Where(id => id.HasValue).Select(id => id.Value).ToList();
                var dongleIds = ds.dongle_id?.Split(',').Select(id => int.TryParse(id, out var result) ? result : (int?)null).Where(id => id.HasValue).Select(id => id.Value).ToList();
                var keyboardIds = ds.keyboard_id?.Split(',').Select(id => int.TryParse(id, out var result) ? result : (int?)null).Where(id => id.HasValue).Select(id => id.Value).ToList();
                var lanIds = ds.lanAdapter_id?.Split(',').Select(id => int.TryParse(id, out var result) ? result : (int?)null).Where(id => id.HasValue).Select(id => id.Value).ToList();
                var monitorIds = ds.monitor_id?.Split(',').Select(id => int.TryParse(id, out var result) ? result : (int?)null).Where(id => id.HasValue).Select(id => id.Value).ToList();
                var mouseIds = ds.mouse_id?.Split(',').Select(id => int.TryParse(id, out var result) ? result : (int?)null).Where(id => id.HasValue).Select(id => id.Value).ToList();
                var upsIds = ds.ups_id?.Split(',').Select(id => int.TryParse(id, out var result) ? result : (int?)null).Where(id => id.HasValue).Select(id => id.Value).ToList();
                var webcamIds = ds.webcam_id?.Split(',').Select(id => int.TryParse(id, out var result) ? result : (int?)null).Where(id => id.HasValue).Select(id => id.Value).ToList();
                var desktopIds = ds.desktop_id?.Split(',').Select(id => int.TryParse(id, out var result) ? result : (int?)null).Where(id => id.HasValue).Select(id => id.Value).ToList();

                return new DesktopSetDto
                {
                    id = ds.id,
                    desktop_id = ds.desktop_id,
                    avr_id = ds.avr_id,
                    dongle_id = ds.dongle_id,
                    keyboard_id = ds.keyboard_id,
                    lanAdapter_id = ds.lanAdapter_id,
                    monitor_id = ds.monitor_id,
                    mouse_id = ds.mouse_id,
                    ups_id = ds.ups_id,
                    assigned = $"{ds.user_id}",
                    status = "Active",
                    li_description = "N/A",
                    webcam_id = ds.webcam_id,

                    Desktops = desktops
                        .Where(desktop => desktopIds != null && desktopIds.Contains(desktop.id))
                        .Select(desktop => new DesktopDto
                        {
                            id = desktop.id,
                            model = desktop.model,
                            color = desktop.color,
                            brand = desktop.brand,
                            status = desktop.status,
                            assigned = desktop.assigned,
                            user_history = desktop.user_history,
                            li_description = desktop.li_description,
                            acquired_date = desktop.acquired_date,
                            asset_barcode = desktop.asset_barcode,
                            serial_no = desktop.serial_no,
                        }).ToList(),

                    // List of Peripherals
                    AVRs = avrs
                        .Where(avr => avrIds != null && avrIds.Contains(avr.id))
                        .Select(avr => new AVRDto
                        {
                            id = avr.id,
                            model = avr.model,
                            color = avr.color,
                            brand = avr.brand,
                            status = avr.status,
                            assigned = avr.assigned,
                            user_history = avr.user_history,
                            set_history = avr.set_history,
                            li_description = avr.li_description,
                            acquired_date = avr.acquired_date,
                            asset_barcode = avr.asset_barcode,
                            serial_no = avr.serial_no,
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

                    UPSs = ups
                        .Where(ups => upsIds != null && upsIds.Contains(ups.id))
                        .Select(ups => new UPSDto
                        {
                            id = ups.id,
                            model = ups.model,
                            color = ups.color,
                            brand = ups.brand,
                            status = ups.status,
                            assigned = ups.assigned,
                            user_history = ups.user_history,
                            set_history = ups.set_history,
                            li_description = ups.li_description,
                            acquired_date = ups.acquired_date,
                            asset_barcode = ups.asset_barcode,
                            serial_no = ups.serial_no,
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
                };
            }).ToList();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<DesktopSet>>> CreateLaptop(DesktopSetDto dto)
        {
            if (dto == null)
            {
                return BadRequest("LaptopSet Data is Required.");
            }


            // Create a new LaptopSet object based on the provided dto
            var set = new DesktopSet
            {
                desktop_id = dto.desktop_id,
                avr_id = dto.avr_id,
                dongle_id = dto.dongle_id,
                keyboard_id = dto.keyboard_id,
                lanAdapter_id = dto.lanAdapter_id,
                monitor_id = dto.monitor_id,
                mouse_id = dto.mouse_id,
                webcam_id = dto.webcam_id,
                user_id = dto.user_id,
                assigned = $"{dto.user_id}",
                status = "Active",
                li_description = "N/A",
                acquired_date = dto.acquired_date,
            };

            try
            {
                // Add and save to generate ID
                _context.DesktopSets.Add(set);
                await _context.SaveChangesAsync();

                // Parse IDs according to their actual type (assuming integers)
                int desktopId = int.Parse(dto.desktop_id);
                int avrId = int.Parse(dto.avr_id);
                int dongleId = int.Parse(dto.dongle_id);
                int keyboardId = int.Parse(dto.keyboard_id);
                int lanAdapterId = int.Parse(dto.lanAdapter_id);
                int monitorId = int.Parse(dto.monitor_id);
                int mouseId = int.Parse(dto.mouse_id);
                int webcamId = int.Parse(dto.webcam_id);
                int upsId = int.Parse(dto.ups_id);



                // Desktop update
                var desktop = await _context.Desktops.FirstOrDefaultAsync(de => de.id == desktopId);
                if (desktop == null) return NotFound("Laptop with the specified laptop_id not found.");

                if (!string.IsNullOrEmpty(dto.user_id))
                {
                    var userIds = desktop.user_history
                        .Split(',')
                        .Select(id => id.Trim())
                        .Where(id => id != "0" && !string.IsNullOrEmpty(id))
                        .ToList();

                    if (!userIds.Contains(dto.user_id)) userIds.Add(dto.user_id);
                    desktop.user_history = string.Join(", ", userIds);
                }
           
                desktop.assigned = set.id.ToString();
                var phTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Manila");
                desktop.date_updated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);

                //AVR update
                var avr = await _context.AVRs.FirstOrDefaultAsync(a => a.id == avrId);
                if (avr != null)
                {
                    var setHistory = avr.set_history
                        .Split(',')
                        .Select(id => id.Trim())
                        .Where(id => !string.IsNullOrEmpty(id))
                        .ToList();
                    setHistory.Add(dto.desktop_id);
                    avr.set_history = string.Join(", ", setHistory);

                    var userHistory = avr.user_history
                      .Split(',')
                      .Select(id => id.Trim())
                      .Where(id => !string.IsNullOrEmpty(id))
                      .ToList();
                    userHistory.Add(dto.user_id);
                    avr.user_history = string.Join(", ", userHistory);
                    avr.date_updated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);

                    _context.AVRs.Update(avr);
                    await _context.SaveChangesAsync();
                }

                // Dongle update
                var dongle = await _context.Dongles.FirstOrDefaultAsync(d => d.id == dongleId);
                if (dongle != null)
                {
                    var setHistory = dongle.set_history
                        .Split(',')
                        .Select(id => id.Trim())
                        .Where(id => !string.IsNullOrEmpty(id))
                        .ToList();
                    setHistory.Add(dto.desktop_id);
                    dongle.set_history = string.Join(", ", setHistory);
               
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
                    setHistory.Add(dto.desktop_id);
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
                    setHistory.Add(dto.desktop_id);
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
                    setHistory.Add(dto.desktop_id);
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
                    setHistory.Add(dto.desktop_id);
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
                    setHistory.Add(dto.desktop_id);
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

                // UPS update
                var ups = await _context.Bags.FirstOrDefaultAsync(u => u.id == upsId);
                if (ups != null)
                {
                    var setHistory = ups.set_history
                        .Split(',')
                        .Select(id => id.Trim())
                        .Where(id => !string.IsNullOrEmpty(id))
                        .ToList();
                    setHistory.Add(dto.desktop_id);
                    ups.set_history = string.Join(", ", setHistory);

                    var userHistory = ups.user_history
                         .Split(',')
                         .Select(id => id.Trim())
                         .Where(id => !string.IsNullOrEmpty(id))
                         .ToList();
                    userHistory.Add(dto.user_id);
                    ups.user_history = string.Join(", ", userHistory);
                    ups.date_updated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);

                    _context.Bags.Update(ups);
                    await _context.SaveChangesAsync();
                }
            
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error occurred: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.Error.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

            return Ok(await _context.LaptopSets.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<DesktopSet>>> UpdateDesktopSet(int id, DesktopSetDto dto)
        {
            if (dto == null)
            {
                return BadRequest("DesktopSet data is required.");
            }

            // Find the existing AVR entity by ID
            var set = await _context.DesktopSets.FindAsync(id);
            if (set == null)
            {
                return NotFound($"No DesktopSet found with ID {id}.");
            }

            // Update the AVR properties
            set.desktop_id = dto.desktop_id;
            set.avr_id = dto.avr_id;
            set.dongle_id = dto.dongle_id;
            set.keyboard_id = dto.keyboard_id;
            set.lanAdapter_id = dto.lanAdapter_id;
            set.monitor_id = dto.monitor_id;
            set.mouse_id = dto.mouse_id;
            set.ups_id = dto.ups_id;
            set.webcam_id = dto.webcam_id;
            set.status = dto.status;
            set.user_id = dto.user_id;
            set.li_description = dto.li_description;
            set.acquired_date = dto.acquired_date;
            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.DesktopSets.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<DesktopSet>>> DeleteDesktopSet(int id)
        {
            // Find the existing AVR entity by ID
            var avr = await _context.DesktopSets.FindAsync(id);
            if (avr == null)
            {
                return NotFound($"No DesktopSet found with ID {id}.");
            }

            // Remove the AVR from the database
            _context.DesktopSets.Remove(avr);
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.DesktopSets.ToListAsync());
        }

    }
}
