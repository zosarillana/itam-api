﻿namespace ITAM_DB.Model.Sets
{
    public class DesktopSet
    {
        public int id { get; set; }
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
        public string assigned {  get; set; } = string.Empty;
        public string li_description { get; set; } = string.Empty;
        public string acquired_date { get; set; } = string.Empty;      
        public DateTime date_created { get; set; }
        public DateTime date_updated { get; set; }
        public DesktopSet()
        {
            var phTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Manila");
            date_created = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);
            date_updated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);
        }
    }
}
