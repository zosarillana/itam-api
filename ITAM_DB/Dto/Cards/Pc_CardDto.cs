using System.ComponentModel.DataAnnotations.Schema;

namespace ITAM_DB.Dto.Cards
{
    public class Pc_CardDto
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
        public string pc_id { get; set; }        
        public string peripheral_id { get; set; }
        public DateTime date_created { get; set; }
        public DateTime date_updated { get; set; }
    }
}
