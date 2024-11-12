namespace ITAM_DB.Dto.Sets
{
    public class LaptopSetDto
    {
        public string desktop_id { get; set; }
        public string dongle_id { get; set; }
        public string keyboard_id { get; set; }
        public string lanAdapter_id { get; set; }
        public string monitor_id { get; set; }
        public string mouse_id { get; set; }
        public string webcam_id { get; set; }
        public string bag_id { get; set; }
        public string externalDrive_id { get; set; } 

        public string user_id { get; set; }
        public string status { get; set; } = string.Empty;
        public string assigned { get; set; } = string.Empty;
        public string li_description { get; set; } = string.Empty;
        public string acquired_date { get; set; } = string.Empty;
    }
}
