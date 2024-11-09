namespace ITAM_DB.Model.Peripherals
{
    public class Dongle
    {
        public int id { get; set; }
        public string model { get; set; } = string.Empty;
        public string color { get; set; } = string.Empty;
        public string brand { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public string assetCode { get; set; } = string.Empty;
        public string acqDate { get; set; } = string.Empty;
        public string srlNumber { get; set; } = string.Empty;
        public DateTime date_created { get; set; }
        public DateTime date_updated { get; set; }
        public Dongle()
        {
            var phTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Manila");
            date_created = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);
            date_updated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);
        }
    }
}
