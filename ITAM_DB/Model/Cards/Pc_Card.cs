using ITAM_API.Model.Operations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITAM_DB.Model.Cards
{
    public class Pc_Card
    {
        public int id { get; set; }
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public string emp_id { get; set; } = string.Empty;
        public string contact_no { get; set; } = string.Empty;
        public string position { get; set; } = string.Empty;
        public string dept_name { get; set; } = string.Empty;
        public string company_name { get; set; } = string.Empty;
        public string location { get; set; } = string.Empty;
        public string date_assigned { get; set; } = string.Empty;

        // Foreign key properties as strings
        public string pc_id { get; set; } // Foreign key for Itot_Pc
        public string peripheral_id { get; set; } // Foreign key for Itot_Peripheral

        public DateTime date_created { get; set; }
        public DateTime date_updated { get; set; }  

        public Pc_Card()
        {
            var phTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Manila");
            date_created = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);
            date_updated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, phTimeZone);
        }
    }
}
