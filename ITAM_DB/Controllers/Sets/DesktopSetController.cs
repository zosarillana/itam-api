﻿using ITAM_API.Data;
using ITAM_DB.Data.Computers;
using ITAM_DB.Data.Peripherals;
using ITAM_DB.Data.Sets;
using ITAM_DB.Dto.Computers.Desktop;
using ITAM_DB.Dto.Peripherals;
using ITAM_DB.Dto.Peripherals.AVR;
using ITAM_DB.Dto.Peripherals.Dongle;
using ITAM_DB.Dto.Peripherals.Keyboard;
using ITAM_DB.Dto.Peripherals.LanAdapterDto;
using ITAM_DB.Dto.Peripherals.Monitor;
using ITAM_DB.Dto.Peripherals.Mouse;
using ITAM_DB.Dto.Peripherals.USP;
using ITAM_DB.Dto.Sets;
using ITAM_DB.Model.Computers;
using ITAM_DB.Model.Peripherals;
using ITAM_DB.Model.Sets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;
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
        public async Task<ActionResult<List<DesktopSet>>> CreateDesktop(DesktopSetDto dto)
        {
            if (dto == null)
            {
                return BadRequest("DesktopSet Data is Required.");
            }

            try
            {
                // Create a new DesktopSet object based on the provided dto
                var set = new DesktopSet
                {
                    desktop_id = dto.desktop_id ?? "",
                    avr_id = dto.avr_id ?? "",
                    dongle_id = dto.dongle_id ?? "",
                    keyboard_id = dto.keyboard_id ?? "",
                    lanAdapter_id = dto.lanAdapter_id ?? "",
                    monitor_id = dto.monitor_id ?? "",
                    mouse_id = dto.mouse_id ?? "",
                    ups_id = dto.ups_id ?? "",
                    webcam_id = dto.webcam_id ?? "",
                    user_id = dto.user_id ?? "",
                    assigned = $"{dto.user_id}",
                    status = "Active",
                    li_description = "N/A",
                    acquired_date = dto.acquired_date ?? DateTime.UtcNow.ToString(),
                };

                // Add the new set first
                _context.DesktopSets.Add(set);
                await _context.SaveChangesAsync();

                var phTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Manila");
                var currentTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);

                // Helper function to safely parse ID
                int SafeParseId(string id) => !string.IsNullOrEmpty(id) ? int.Parse(id) : 0;

                // Helper function to update history
                //string UpdateHistory(string currentHistory, string newId)
                //{
                //    if (string.IsNullOrEmpty(currentHistory)) return newId;
                //    var history = currentHistory.Split(',')
                //        .Select(id => id.Trim())
                //        .Where(id => !string.IsNullOrEmpty(id))
                //        .ToList();
                //    if (!history.Contains(newId)) history.Add(newId);
                //    return string.Join(", ", history);
                //}

                // Helper function to update history - modified to allow repeated values
                string UpdateHistory(string currentHistory, string newId)
                {
                    if (string.IsNullOrEmpty(currentHistory)) return newId;

                    var history = currentHistory.Split(',')
                        .Select(id => id.Trim())
                        .Where(id => !string.IsNullOrEmpty(id))
                        .ToList();

                    // Always add the new ID, even if it already exists
                    history.Add(newId);

                    return string.Join(", ", history);
                }

                // Desktop update
                if (!string.IsNullOrEmpty(dto.desktop_id))
                {
                    var desktopId = SafeParseId(dto.desktop_id);
                    var desktop = await _context.Desktops.FirstOrDefaultAsync(d => d.id == desktopId);
                    if (desktop != null)
                    {
                        desktop.user_history = UpdateHistory(desktop.user_history, dto.user_id);
                        //desktop.user_history = UpdateHistory(desktop.user_history, dto.user_id);
                        desktop.assigned = set.id.ToString();
                        desktop.date_updated = currentTime;
                        _context.Desktops.Update(desktop);
                        await _context.SaveChangesAsync();
                    }
                }

                // AVR update
                if (!string.IsNullOrEmpty(dto.avr_id))
                {
                    var avrId = SafeParseId(dto.avr_id);
                    var avr = await _context.AVRs.FirstOrDefaultAsync(a => a.id == avrId);
                    if (avr != null)
                    {
                        avr.set_history = UpdateHistory(avr.set_history, dto.desktop_id);
                        avr.user_history = UpdateHistory(avr.user_history, dto.user_id);
                        avr.date_updated = currentTime;
                        _context.AVRs.Update(avr);
                        await _context.SaveChangesAsync();
                    }
                }

                // Dongle update
                if (!string.IsNullOrEmpty(dto.dongle_id))
                {
                    var dongleId = SafeParseId(dto.dongle_id);
                    var dongle = await _context.Dongles.FirstOrDefaultAsync(d => d.id == dongleId);
                    if (dongle != null)
                    {
                        dongle.set_history = UpdateHistory(dongle.set_history, dto.desktop_id);
                        dongle.user_history = UpdateHistory(dongle.user_history, dto.user_id);
                        dongle.date_updated = currentTime;
                        _context.Dongles.Update(dongle);
                        await _context.SaveChangesAsync();
                    }
                }

                // Keyboard update
                if (!string.IsNullOrEmpty(dto.keyboard_id))
                {
                    var keyboardId = SafeParseId(dto.keyboard_id);
                    var keyboard = await _context.Keyboards.FirstOrDefaultAsync(k => k.id == keyboardId);
                    if (keyboard != null)
                    {
                        keyboard.set_history = UpdateHistory(keyboard.set_history, dto.desktop_id);
                        keyboard.user_history = UpdateHistory(keyboard.user_history, dto.user_id);
                        keyboard.date_updated = currentTime;
                        _context.Keyboards.Update(keyboard);
                        await _context.SaveChangesAsync();
                    }
                }

                // LAN Adapter update
                if (!string.IsNullOrEmpty(dto.lanAdapter_id))
                {
                    var lanAdapterId = SafeParseId(dto.lanAdapter_id);
                    var lanAdapter = await _context.LanAdapters.FirstOrDefaultAsync(l => l.id == lanAdapterId);
                    if (lanAdapter != null)
                    {
                        lanAdapter.set_history = UpdateHistory(lanAdapter.set_history, dto.desktop_id);
                        lanAdapter.user_history = UpdateHistory(lanAdapter.user_history, dto.user_id);
                        lanAdapter.date_updated = currentTime;
                        _context.LanAdapters.Update(lanAdapter);
                        await _context.SaveChangesAsync();
                    }
                }

                // Monitor update
                if (!string.IsNullOrEmpty(dto.monitor_id))
                {
                    var monitorId = SafeParseId(dto.monitor_id);
                    var monitor = await _context.Monitors.FirstOrDefaultAsync(m => m.id == monitorId);
                    if (monitor != null)
                    {
                        monitor.set_history = UpdateHistory(monitor.set_history, dto.desktop_id);
                        monitor.user_history = UpdateHistory(monitor.user_history, dto.user_id);
                        monitor.date_updated = currentTime;
                        _context.Monitors.Update(monitor);
                        await _context.SaveChangesAsync();
                    }
                }

                // Mouse update
                if (!string.IsNullOrEmpty(dto.mouse_id))
                {
                    var mouseId = SafeParseId(dto.mouse_id);
                    var mouse = await _context.Mouses.FirstOrDefaultAsync(m => m.id == mouseId);
                    if (mouse != null)
                    {
                        mouse.set_history = UpdateHistory(mouse.set_history, dto.desktop_id);
                        mouse.user_history = UpdateHistory(mouse.user_history, dto.user_id);
                        mouse.date_updated = currentTime;
                        _context.Mouses.Update(mouse);
                        await _context.SaveChangesAsync();
                    }
                }

                // UPS update
                if (!string.IsNullOrEmpty(dto.ups_id))
                {
                    var upsId = SafeParseId(dto.ups_id);
                    var ups = await _context.UPSs.FirstOrDefaultAsync(u => u.id == upsId);
                    if (ups != null)
                    {
                        ups.set_history = UpdateHistory(ups.set_history, dto.desktop_id);
                        ups.user_history = UpdateHistory(ups.user_history, dto.user_id);
                        ups.date_updated = currentTime;
                        _context.UPSs.Update(ups);
                        await _context.SaveChangesAsync();
                    }
                }

                // WebCam update
                if (!string.IsNullOrEmpty(dto.webcam_id))
                {
                    var webcamId = SafeParseId(dto.webcam_id);
                    var webcam = await _context.WebCams.FirstOrDefaultAsync(w => w.id == webcamId);
                    if (webcam != null)
                    {
                        webcam.set_history = UpdateHistory(webcam.set_history, dto.desktop_id);
                        webcam.user_history = UpdateHistory(webcam.user_history, dto.user_id);
                        webcam.date_updated = currentTime;
                        _context.WebCams.Update(webcam);
                        await _context.SaveChangesAsync();
                    }
                }

                return Ok(await _context.DesktopSets.ToListAsync());
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException;
                Console.Error.WriteLine($"Database Update Error: {ex.Message}");
                Console.Error.WriteLine($"Inner Exception: {innerException?.Message}");
                Console.Error.WriteLine($"Stack Trace: {ex.StackTrace}");
                return StatusCode(500, $"Database error: {innerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error occurred: {ex.Message}");
                Console.Error.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                Console.Error.WriteLine($"Stack Trace: {ex.StackTrace}");
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
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
