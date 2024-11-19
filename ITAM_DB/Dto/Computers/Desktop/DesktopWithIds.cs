namespace ITAM_DB.Dto.Computers.Desktop
{
    public class DesktopWithIds
    {
        public int id { get; set; }
        public string brand { get; set; } = string.Empty;
        public string model { get; set; } = string.Empty;
        public string processor { get; set; } = string.Empty;
        public string ram { get; set; } = string.Empty;
        public string storage_capacity { get; set; } = string.Empty;
        public string storage_type { get; set; } = string.Empty;
        public string operating_system { get; set; } = string.Empty;
        public string graphics { get; set; } = string.Empty;
        public string color { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public string assigned { get; set; } = string.Empty;
        public string? user_history { get; set; } = string.Empty;
        public string li_description { get; set; } = string.Empty;
        public string acquired_date { get; set; } = string.Empty;
        public string asset_barcode { get; set; } = string.Empty;
        public string serial_no { get; set; } = string.Empty;
        public DateTime date_created { get; set; }
        public DateTime date_updated { get; set; }
    }
}
