using ITAM_API.Data;
using ITAM_API.Data.Itot;
using ITAM_API.Model.Operations;
using ITAM_DB.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITAM_DB.Controllers.Itot
{
    [ApiController]
    [Route("[controller]")]
    public class ImportItotController : ControllerBase
    {
        private readonly ItotContext _context; // Your DbContext
        private readonly ILogger<ImportItotController> _logger;

        public ImportItotController(ItotContext context, ILogger<ImportItotController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // POST: /ImportItot/update
        [HttpPost("update/pc")]
        public async Task<IActionResult> UploadExcelData([FromBody] List<Itot_PcDto> data)
        {
            if (data == null || data.Count == 0)
            {
                return BadRequest(new { Message = "No data received." });
            }

            // Flag to check if any insert was successful
            bool isUploadSuccessful = false;

            foreach (var row in data)
            {
                try
                {
                    // Create a new instance of Itot_Pc based on the DTO
                    var itot_pc = new Itot_Pc
                    {
                        asset_barcode = row.asset_barcode,                      
                        date_acquired = row.date_acquired, // Ensure the format is correct
                        pc_type = row.pc_type,
                        brand = row.brand,
                        model = row.model,
                        processor = row.processor,
                        ram = row.ram,
                        storage_capacity = row.storage_capacity,
                        storage_type = row.storage_type,
                        operating_system = row.operating_system,
                        graphics = row.graphics,
                        size = row.size,
                        color = row.color,
                        li_description = row.li_description,
                        serial_no = row.serial_no,
                        assigned = "Not Assigned",
                        status = "Active"
                    };

                    // Add the new entity to the context
                    await _context.Itot_Pcs.AddAsync(itot_pc); // AddAsync for better async performance
                    isUploadSuccessful = true; // Set to true if at least one item is processed successfully
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error processing row: {ex.Message}");
                    // You may want to return the error response here or continue with the next item
                }
            }

            // Save changes to the database
            if (isUploadSuccessful)
            {
                await _context.SaveChangesAsync(); // Commit all changes
                return Ok(new { Message = "Data uploaded successfully." });
            }
            else
            {
                return BadRequest(new { Message = "No data was uploaded." });
            }
        }

        [HttpPost("update/peripherals")]
        public async Task<IActionResult> UploadExcelDataPeripherals([FromBody] List<Itot_PeripheralDto> data)
        {
            if (data == null || data.Count == 0)
            {
                return BadRequest(new { Message = "No data received." });
            }

            // Flag to check if any insert was successful
            bool isUploadSuccessful = false;

            foreach (var row in data)
            {
                try
                {
                    // Create a new instance of Itot_Pc based on the DTO
                    var itot_peripherals = new Itot_Peripheral
                    {

                        date_acquired = row.date_acquired, // Ensure the format is correct                                               
                        brand = row.brand,
                        model = row.model,
                        asset_barcode = row.asset_barcode,
                        peripheral_type = row.peripheral_type,
                        size = row.size,
                        color = row.color,
                        li_description = row.li_description,
                        serial_no = row.serial_no,
                        assigned = "Not Assigned",
                        status = "Active"

                    };

                    // Add the new entity to the context
                    await _context.Itot_Peripherals.AddAsync(itot_peripherals); // AddAsync for better async performance
                    isUploadSuccessful = true; // Set to true if at least one item is processed successfully
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error processing row: {ex.Message}");
                    // You may want to return the error response here or continue with the next item
                }
            }

            // Save changes to the database
            if (isUploadSuccessful)
            {
                await _context.SaveChangesAsync(); // Commit all changes
                return Ok(new { Message = "Data uploaded successfully." });
            }
            else
            {
                return BadRequest(new { Message = "No data was uploaded." });
            }
        }
    }
}
