namespace ITAM_DB.Model.User
{
    public class User
    {
        public int id { get; set; }
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public string emp_id { get; set; } = string.Empty;
        public string contact_no { get; set; } = string.Empty;
        public string position { get; set; } = string.Empty;
        public string dept_name { get; set; } = string.Empty;
        public string company_name { get; set; } = string.Empty;

        public DateTime date_created { get; set; }
        public DateTime date_updated { get; set; }

        public User()
        {
            var phTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Manila");
            date_created = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);
            date_updated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);
        }
    }
}
