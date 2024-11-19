using ITAM_DB.Dto.Computers.Desktop;
using ITAM_DB.Dto.Peripherals;
using ITAM_DB.Dto.Peripherals.AVR;
using ITAM_DB.Dto.Peripherals.Dongle;
using ITAM_DB.Dto.Peripherals.Keyboard;
using ITAM_DB.Dto.Peripherals.LanAdapterDto;
using ITAM_DB.Dto.Peripherals.Monitor;
using ITAM_DB.Dto.Peripherals.Mouse;
using ITAM_DB.Dto.Peripherals.USP;
using ITAM_DB.Migrations;

namespace ITAM_DB.Dto.Sets
{
    public class DesktopSetDto
    {
        public int id {  get; set; }
        public string desktop_id { get; set; }
        public string avr_id { get; set; }
        public string dongle_id { get; set; }
        public string keyboard_id { get; set; }
        public string lanAdapter_id { get; set; }
        public string monitor_id { get; set; }
        public string mouse_id { get; set; }
        public string ups_id { get; set; }
        public string webcam_id { get; set; }
        public string assigned {  get; set; }
        public string status { get; set; } = string.Empty;
        public string user_id { get; set; } = string.Empty;
        public string li_description { get; set; } = string.Empty;
        public string acquired_date { get; set; } = string.Empty;
        public DateTime date_created { get; set; }
        public DateTime date_updated { get; set; }
  
        public List<DesktopDto> Desktops { get; set; }    
        public List<AVRDto> AVRs { get; set; }
        public List<DongleDto> Dongles { get; set; }
        public List<KeyboardDto> Keyboards { get; set; }
        public List<LanAdapterDto> LanAdapters { get; set; }
        public List<MonitorDto> Monitors { get; set; }
        public List<MouseDto> Mouses { get; set; }
        public List<UPSDto> UPSs { get; set; }
        public List<WebCamDto> WebCams { get; set; }
    }
}
