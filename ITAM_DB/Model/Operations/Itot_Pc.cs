using System.ComponentModel.DataAnnotations;

namespace ITAM_API.Model.Operations
{
    public class Itot_Pc
    {
        public int id { get; set; }
        public string accountable_user { get; set; } = string.Empty;
        public string bu { get; set; } = string.Empty;
        public string department { get; set; } = string.Empty;
        public string date_acquired { get; set; } = string.Empty;
        public string inventory_tag { get; set; } = string.Empty;
        public string brand { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public string model { get; set; } = string.Empty;
        public string processor { get; set; } = string.Empty;
        public string ram { get; set; } = string.Empty;
        public string storage_capacity { get; set; } = string.Empty;
        public string storage_type { get; set; } = string.Empty;
        public string operating_system { get; set; } = string.Empty;
        public string graphics { get; set; } = string.Empty;
        public string size { get; set; } = string.Empty;
        public string color { get; set; } = string.Empty;
        public string serial_no { get; set; } = string.Empty;
        public string location { get; set; } = string.Empty;
        public DateTime date_created { get; set; }
        public DateTime date_updated { get; set; }
        public Itot_Pc()
        {
            var phTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Manila");
            date_created = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);
            date_updated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);
        }
    }
}
