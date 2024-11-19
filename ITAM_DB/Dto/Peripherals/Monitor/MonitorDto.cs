using ITAM_DB.Dto.Computers;
using ITAM_DB.Dto.User;
using System.Text.Json.Serialization;

namespace ITAM_DB.Dto.Peripherals.Monitor
{
    public class MonitorDto
    {
        public int id { get; set; }
        public string? model { get; set; }
        public string? size { get; set; }
        public string? color { get; set; }
        public string? brand { get; set; }
        public string status { get; set; }
        public string? assigned { get; set; } // String representation
        public string? user_history { get; set; }
        public string? set_history { get; set; }
        public string? li_description { get; set; }
        public string? acquired_date { get; set; }
        public string? asset_barcode { get; set; }
        public string? serial_no { get; set; }
        public DateTime? date_created { get; set; }
        public DateTime? date_updated { get; set; }

        // Relationships with other entities
        //[JsonPropertyName("assignedUsers")] // Ensure distinct JSON property name
        //public List<UserDto> Assigned { get; set; } // Renamed in JSON to "assignedUsers"

        //[JsonPropertyName("userHistory")]
        //public List<UserDto> UserHistory { get; set; }

        //[JsonPropertyName("setHistory")]
        //public List<DesktopDto> SetHistory { get; set; }
    }

}
