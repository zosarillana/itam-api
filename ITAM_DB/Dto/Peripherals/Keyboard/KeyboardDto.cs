﻿namespace ITAM_DB.Dto.Peripherals.Keyboard
{
    public class KeyboardDto
    {
        public int id { get; set; }
        public string model { get; set; } = string.Empty;
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
    }
}
