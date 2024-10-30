namespace ITAM_DB.Dto
{
    public class Itot_PeripheralDto
    {
        public int id { get; set; }    
        public string date_acquired { get; set; } = string.Empty;
        public string asset_barcode { get; set; } = string.Empty;
        public string peripheral_type { get; set; }
        public string li_description { get; set; }
        public string size { get; set; }
        public string brand { get; set; } = string.Empty;        
        public string model { get; set; } = string.Empty;
        public string color { get; set; } = string.Empty;
        public string serial_no { get; set; } = string.Empty;
        public string assigned { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public string history { get; set; } = string.Empty;
        public string location { get; set; } = string.Empty;
        public DateTime date_created { get; set; }
        public DateTime date_updated { get; set; }
    }
}
