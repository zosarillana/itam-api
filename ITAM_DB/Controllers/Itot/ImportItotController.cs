using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITAM_DB.Controllers.Itot
{
    [ApiController]
    [Route("[controller]")]
    public class ImportItotController : ControllerBase
    {
        // POST: /ImportItot/update
        [HttpPost("update")]
        public async Task<IActionResult> UploadExcelData([FromBody] List<List<object>> data)
        {
            if (data == null || data.Count == 0)
            {
                return BadRequest(new { Message = "No data received." });
            }

            // Process the data here (e.g., save to the database)
            foreach (var row in data)
            {
                // Example: Each row will be a list of objects, process them as needed
                // You might want to convert them to a specific model and save them to the database
            }

            // Return a success response
            return Ok(new { Message = "Data uploaded successfully." });
        }
    }
}
