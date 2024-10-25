namespace ITAM_DB.Dto
{
    public class Itot_PcDto
    {
        public int id { get; set; }
        public string asset_barcode { get; set; } = string.Empty;
        public string date_acquired { get; set; } = string.Empty;
        public string pc_type { get; set; } = string.Empty;
        public string brand { get; set; } = string.Empty;
        public string model { get; set; } = string.Empty;
        public string processor { get; set; } = string.Empty;
        public string ram { get; set; } = string.Empty;
        public string storage_capacity { get; set; } = string.Empty;
        public string storage_type { get; set; } = string.Empty;
        public string operating_system { get; set; } = string.Empty;
        public string graphics { get; set; } = string.Empty;
        public string size { get; set; } = string.Empty;
        public string color { get; set; } = string.Empty;
        public string li_description { get; set; } = string.Empty;
        public string serial_no { get; set; } = string.Empty;
        public string assigned { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public DateTime date_created { get; set; }
        public DateTime date_updated { get; set; }
    }
}
