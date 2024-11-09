using Microsoft.AspNetCore.Mvc;

namespace ITAM_DB.Controllers.Peripherals
{
    public class ExternalDriveController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
