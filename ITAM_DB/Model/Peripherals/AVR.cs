﻿namespace ITAM_DB.Model.Peripherals
{
    public class AVR
    {
        public int id { get; set; }
        public string color { get; set; } = string.Empty;
        public string brand { get; set; } = string.Empty;
        public string model { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public string assigned { get; set; } = string.Empty;
        public string li_description { get; set; } = string.Empty;
        public string acquired_date { get; set; } = string.Empty;
        public string asset_barcode { get; set; } = string.Empty;
        public string serial_no { get; set; } = string.Empty;
        public DateTime date_created { get; set; }
        public DateTime date_updated { get; set; }
        public AVR()
        {
            var phTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Manila");
            date_created = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);
            date_updated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);
        }
    }
}
