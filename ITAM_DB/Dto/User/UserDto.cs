namespace ITAM_DB.Dto.User
{
    public class UserDto
    {
        public int id { get; set; }
        public string first_name { get; set; } = string.Empty;
        public string middle_name {  get; set; } = string.Empty;
        public string last_name { get; set; } = string.Empty;
        public string emp_id { get; set; } = string.Empty;
        public string contact_no { get; set; } = string.Empty;
        public string position { get; set; } = string.Empty;
        public string dept_name { get; set; } = string.Empty;
        public string company_name { get; set; } = string.Empty;
        public DateTime date_created { get; set; }
        public DateTime date_updated { get; set; }

    }
}
