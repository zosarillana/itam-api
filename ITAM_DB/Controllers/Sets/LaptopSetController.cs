using ITAM_API.Data;
using ITAM_DB.Data.Computers;
using ITAM_DB.Data.Sets;
using ITAM_DB.Dto.Computers;
using ITAM_DB.Dto.Peripherals;
using ITAM_DB.Dto.Sets;
using ITAM_DB.Model.Computers;
using ITAM_DB.Model.Sets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<LaptopSet>>> GetAllLaptop()
        //{
        //    var avrs = await _context.LaptopSets.ToListAsync(); // Use your DbSet for AVR
        //    return Ok(avrs); // Return 200 OK with the list of items
        //}
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
                //var desktopIds = ds.desktop_id?.Split(',').Select(id => int.TryParse(id, out var result) ? result : (int?)null).Where(id => id.HasValue).Select(id => id.Value).ToList();
                //var laptopsets = ds.laptop_id?.Split(',').Select(id => int.TryParse(id, out var result) ? result : (int?)null).Where(id => id.HasValue).Select(id => id.Value).ToList();

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
                };
            }).ToList();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<LaptopSet>>> CreateLaptop(LaptopSetDto dto)
        {
            if (dto == null)
            {
                return BadRequest("LaptopSet Data is Required,");
            }

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
                externalDrive_id = dto.bag_id,
                user_id = dto.user_id,
                status = dto.status,                
                li_description = dto.li_description,
                acquired_date = dto.acquired_date,
            };
            _context.LaptopSets.Add(set);
            await _context.SaveChangesAsync();

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
