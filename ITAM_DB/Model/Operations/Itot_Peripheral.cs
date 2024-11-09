namespace ITAM_API.Model.Operations
{
    public class Itot_Peripheral
    {
        public int id { get; set; }        
        public string date_acquired { get; set; } = string.Empty;              
        public string brand { get; set; } = string.Empty;
        public string model { get; set; } = string.Empty;        
        public string asset_barcode { get; set; } = string.Empty;
        public string peripheral_type { get; set; } = string.Empty;
        public string size { get; set; } = string.Empty;
        public string color { get; set; } = string.Empty;
        public string? li_description { get; set; } = string.Empty;
        public string serial_no { get; set; } = string.Empty;
        public string assigned { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public string history { get; set; } = string.Empty;
        public DateTime date_created { get; set; }
        public DateTime date_updated { get; set; }
        public Itot_Peripheral()
        {
            var phTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Manila");
            date_created = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);
            date_updated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);
        }
    }
}
