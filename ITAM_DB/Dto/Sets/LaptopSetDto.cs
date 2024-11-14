using ITAM_DB.Dto.Computers;
using ITAM_DB.Dto.Peripherals;
using ITAM_DB.Model.User;
using UserModel = ITAM_DB.Model.User.User;

namespace ITAM_DB.Dto.Sets
{
    public class LaptopSetDto
    {
        public int id { get; set; }
        public string laptop_id { get; set; }
        public string dongle_id { get; set; }
        public string keyboard_id { get; set; }
        public string lanAdapter_id { get; set; }
        public string monitor_id { get; set; }
        public string mouse_id { get; set; }
        public string webcam_id { get; set; }
        public string bag_id { get; set; }
        public string externalDrive_id { get; set; } 
        public string user_id { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public string assigned { get; set; } 
        public string li_description { get; set; } = string.Empty;
        public string acquired_date { get; set; } = string.Empty;

        public DateTime date_created { get; set; }
        public DateTime date_updated { get; set; }

        public List<LaptopDto> Laptops { get; set; }        
        public List<DongleDto> Dongles { get; set; }
        public List<KeyboardDto> Keyboards { get; set; }
        public List<LanAdapterDto> LanAdapters { get; set; }
        public List<MonitorDto> Monitors { get; set; }
        public List<MouseDto> Mouses { get; set; }        
        public List<WebCamDto> WebCams { get; set; }
        public List<BagDto> Bags { get; set; }
        public List<ExternalDriveDto> ExternalDrives { get; set; }  
        public List<UserModel> Users { get; set; }
    }
}
