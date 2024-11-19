using ITAM_DB.Dto.Computers.Desktop;
using ITAM_DB.Dto.User;
using System.Text.Json.Serialization;

namespace ITAM_DB.Dto.Peripherals.Bag
{
    public class BagWithIds
    {
        public int id { get; set; }
        public string color { get; set; } = string.Empty;
        public string brand { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public string assigned { get; set; } = string.Empty;
        public string? user_history { get; set; } = string.Empty;
        public string? set_history { get; set; } = string.Empty;
        public string li_description { get; set; } = string.Empty;
        public string acquired_date { get; set; } = string.Empty;
        public string asset_barcode { get; set; } = string.Empty;
        public string serial_no { get; set; } = string.Empty;

        public DateTime date_created { get; set; }
        public DateTime date_updated { get; set; }

        // Relationships with other entities
        [JsonPropertyName("assignedUsers")] // Ensure distinct JSON property name
        public List<UserDto> Assigned { get; set; } // Renamed in JSON to "assignedUsers"

        [JsonPropertyName("userHistory")]
        public List<UserDto> UserHistory { get; set; }

        [JsonPropertyName("setHistory")]
        public List<DesktopDto> SetHistory { get; set; }
    }
}
