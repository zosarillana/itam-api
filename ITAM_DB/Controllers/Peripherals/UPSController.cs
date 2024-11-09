using Microsoft.AspNetCore.Mvc;

namespace ITAM_DB.Controllers.Peripherals
{
    public class UPSController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
