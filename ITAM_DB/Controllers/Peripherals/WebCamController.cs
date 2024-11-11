using ITAM_DB.Data.Peripherals;
using ITAM_DB.Dto.Peripherals;
using ITAM_DB.Model.Peripherals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace ITAM_DB.Controllers.Peripherals
{
    [ApiController]
    [Route("[controller]")]
    public class WebCamController : Controller
    {
        private readonly WebCamContext _context;
        public WebCamController(WebCamContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WebCam>>> GetAllWebCam()
        {
            var webcs = await _context.WebCams.ToListAsync(); // Use your DbSet for AVR
            return Ok(webcs); // Return 200 OK with the list of items
        }

        [HttpPost]
        public async Task<ActionResult<List<WebCam>>> CreateAVR(WebCamDto dto)
        {
            if (dto == null)
            {
                return BadRequest("WebCam Data is Required,");
            }

            var webc = new WebCam
            {
                model = dto.model,
                color = dto.color,
                brand = dto.brand,
                status = dto.status,
                assigned = dto.assigned,
                li_description = dto.li_description,
                acquired_date = dto.acquired_date,
                asset_barcode = dto.asset_barcode,
                serial_no = dto.serial_no,
            };
            _context.WebCams.Add(webc);
            await _context.SaveChangesAsync();

            return Ok(await _context.WebCams.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<WebCam>>> UpdateAVR(int id, WebCamDto dto)
        {
            if (dto == null)
            {
                return BadRequest("WebCam data is required.");
            }

            // Find the existing AVR entity by ID
            var webcs = await _context.WebCams.FindAsync(id);
            if (webcs == null)
            {
                return NotFound($"No WebCam found with ID {id}.");
            }

            // Update the AVR properties
            webcs.model = dto.model;
            webcs.color = dto.color;
            webcs.brand = dto.brand;
            webcs.model = dto.model;
            webcs.color = dto.color;
            webcs.brand = dto.brand;
            webcs.status = dto.status;
            webcs.assigned = dto.assigned;
            webcs.li_description = dto.li_description;
            webcs.acquired_date = dto.acquired_date;
            webcs.asset_barcode = dto.asset_barcode;
            webcs.serial_no = dto.serial_no;


            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.WebCams.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<AVR>>> DeleteAVR(int id)
        {
            // Find the existing AVR entity by ID
            var webcs = await _context.WebCams.FindAsync(id);
            if (webcs == null)
            {
                return NotFound($"No WebCam found with ID {id}.");
            }

            // Remove the AVR from the database
            _context.WebCams.Remove(webcs);
            await _context.SaveChangesAsync();

            // Return the updated list of AVRs
            return Ok(await _context.WebCams.ToListAsync());
        }



    }
}
