using ITAM_API.Data;
using ITAM_DB.Data.Computers;
using ITAM_DB.Data.Peripherals;
using ITAM_DB.Data.Sets;
using ITAM_DB.Dto.Computers;
using ITAM_DB.Dto.Peripherals;
using ITAM_DB.Dto.Sets;
using ITAM_DB.Model.Peripherals;
using ITAM_DB.Model.Sets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<DesktopSetDto>>> GetAllDesktopSets()
        //{
        //    var avrs = await _context.DesktopSets.ToListAsync(); // Use your DbSet for AVR
        //    return Ok(avrs); // Return 200 OK with the list of items
        //}

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

            var result = desktopsets
                .Select(ds =>
                {
                    // Split the comma-separated pc_ids and peripheral_ids
                    var avrIds = ds.avr_id?.Split(',').Select(id => int.TryParse(id, out var result) ? result : (int?)null).Where(id => id.HasValue).Select(id => id.Value).ToList();
                    var dongleIds = ds.dongle_id?.Split(',').Select(id => int.TryParse(id, out var result) ? result : (int?)null).Where(id => id.HasValue).Select(id => id.Value).ToList();
                    var keyboardIds = ds.keyboard_id?.Split(',').Select(id => int.TryParse(id, out var result) ? result : (int?)null).Where(id => id.HasValue).Select(id => id.Value).ToList();
                    var lanIds = ds.lanAdapter_id?.Split(',').Select(id => int.TryParse(id, out var result) ? result : (int?)null).Where(id => id.HasValue).Select(id => id.Value).ToList();
                    var monitorIds = ds.monitor_id?.Split(',').Select(id => int.TryParse(id, out var result) ? result : (int?)null).Where(id => id.HasValue).Select(id => id.Value).ToList();
                    var mousesIds = ds.mouse_id?.Split(',').Select(id => int.TryParse(id, out var result) ? result : (int?)null).Where(id => id.HasValue).Select(id => id.Value).ToList();
                    var upsIds = ds.ups_id?.Split(',').Select(id => int.TryParse(id, out var result) ? result : (int?)null).Where(id => id.HasValue).Select(id => id.Value).ToList();
                    var webcamIds = ds.webcam_id?.Split(',').Select(id => int.TryParse(id, out var result) ? result : (int?)null).Where(id => id.HasValue).Select(id => id.Value).ToList();

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
                        webcam_id = ds.webcam_id,

                        //List of Peripherals
                        AVRs = avrs
                            .Where(avr => avrIds != null && avrIds.Contains(ds.id))
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
                            })
                            .ToList(),

                        Dongles = dongles
                            .Where(dongles => dongleIds != null && dongleIds.Contains(ds.id))
                            .Select(dongles => new DongleDto
                            {
                                id = dongles.id,
                                model = dongles.model,
                                color = dongles.color,
                                brand = dongles.brand,
                                type = dongles.type,
                                status = dongles.status,
                                assigned = dongles.assigned,
                                user_history = dongles.user_history,
                                set_history = dongles.set_history,
                                li_description = dongles.li_description,
                                acquired_date = dongles.acquired_date,
                                asset_barcode = dongles.asset_barcode,
                                serial_no = dongles.serial_no,
                            })
                            .ToList(),

                        Keyboards = keyboards
                             .Where(keyboards => keyboardIds != null && keyboardIds.Contains(ds.id))
                            .Select(keyboards => new KeyboardDto
                            {
                                id = keyboards.id,
                                model = keyboards.model,
                                color = keyboards.color,
                                brand = keyboards.brand,
                                type = keyboards.type,
                                status = keyboards.status,
                                assigned = keyboards.assigned,
                                user_history = keyboards.user_history,
                                set_history = keyboards.set_history,
                                li_description = keyboards.li_description,
                                acquired_date = keyboards.acquired_date,
                                asset_barcode = keyboards.asset_barcode,
                                serial_no = keyboards.serial_no,
                            })
                            .ToList(),

                        LanAdapters = lanadapters
                             .Where(lanadapters => lanIds != null && lanIds.Contains(ds.id))
                            .Select(lanadapters => new LanAdapterDto
                            {
                                id = lanadapters.id,
                                model = lanadapters.model,
                                color = lanadapters.color,
                                brand = lanadapters.brand,
                                type = lanadapters.type,
                                status = lanadapters.status,
                                assigned = lanadapters.assigned,
                                user_history = lanadapters.user_history,
                                set_history = lanadapters.set_history,
                                li_description = lanadapters.li_description,
                                acquired_date = lanadapters.acquired_date,
                                asset_barcode = lanadapters.asset_barcode,
                                serial_no = lanadapters.serial_no,
                            })
                            .ToList(),

                        Monitors = monitors
                             .Where(monitors => monitorIds != null && monitorIds.Contains(ds.id))
                            .Select(monitors => new MonitorDto
                            {
                                id = monitors.id,
                                model = monitors.model,
                                color = monitors.color,
                                brand = monitors.brand,                                
                                status = monitors.status,
                                assigned = monitors.assigned,
                                user_history = monitors.user_history,
                                set_history = monitors.set_history,
                                li_description = monitors.li_description,
                                acquired_date = monitors.acquired_date,
                                asset_barcode = monitors.asset_barcode,
                                serial_no = monitors.serial_no,
                            })
                            .ToList(),

                        Mouses = mouses
                             .Where(mouses => mousesIds != null && mousesIds.Contains(ds.id))
                            .Select(mouses => new MouseDto
                            {
                                id = mouses.id,
                                model = mouses.model,
                                color = mouses.color,
                                brand = mouses.brand,
                                status = mouses.status,
                                type = mouses.type,
                                assigned = mouses.assigned,
                                user_history = mouses.user_history,
                                set_history = mouses.set_history,
                                li_description = mouses.li_description,
                                acquired_date = mouses.acquired_date,
                                asset_barcode = mouses.asset_barcode,
                                serial_no = mouses.serial_no,
                            })
                            .ToList(),

                        UPSs = ups
                             .Where(ups => upsIds != null && upsIds.Contains(ds.id))
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
                            })
                            .ToList(),

                        WebCams = webcams
                             .Where(webcams => webcamIds != null && webcamIds.Contains(ds.id))
                            .Select(webcams => new WebCamDto
                            {
                                id = webcams.id,
                                model = webcams.model,
                                color = webcams.color,
                                brand = webcams.brand,
                                status = webcams.status,
                                assigned = webcams.assigned,
                                user_history = webcams.user_history,
                                set_history = webcams.set_history,
                                li_description = webcams.li_description,
                                acquired_date = webcams.acquired_date,
                                asset_barcode = webcams.asset_barcode,
                                serial_no = webcams.serial_no,
                            })
                            .ToList(),
                    };
                })
                .ToList();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<DesktopSet>>> CreateDesktopSet(DesktopSetDto dto)
        {
            if (dto == null)
            {
                return BadRequest("DesktopSet Data is Required,");
            }

            var set = new DesktopSet
            {
                desktop_id = dto.desktop_id,
                avr_id = dto.avr_id,
                dongle_id = dto.dongle_id,
                keyboard_id = dto.keyboard_id,
                lanAdapter_id = dto.lanAdapter_id,
                monitor_id = dto.monitor_id,
                mouse_id = dto.mouse_id,
                ups_id = dto.ups_id,
                webcam_id = dto.webcam_id,
                status = dto.status,
                user_id = dto.user_id,
                li_description = dto.li_description,
                acquired_date = dto.acquired_date,
                
            };
            _context.DesktopSets.Add(set);
            await _context.SaveChangesAsync();

            return Ok(await _context.DesktopSets.ToListAsync());
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
