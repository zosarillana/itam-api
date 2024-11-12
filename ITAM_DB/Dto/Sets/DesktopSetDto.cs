namespace ITAM_DB.Dto.Sets
{
    public class DesktopSetDto
    {
        public string desktop_id { get; set; }
        public string avr_id { get; set; }
        public string dongle_id { get; set; }
        public string keyboard_id { get; set; }
        public string lanAdapter_id { get; set; }
        public string monitor_id { get; set; }
        public string mouse_id { get; set; }
        public string ups_id { get; set; }
        public string webcam_id { get; set; }
        public string status { get; set; } = string.Empty;
        public string user_id { get; set; } = string.Empty;
        public string li_description { get; set; } = string.Empty;
        public string acquired_date { get; set; } = string.Empty;
    }
}
