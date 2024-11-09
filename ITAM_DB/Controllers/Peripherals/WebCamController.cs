using Microsoft.AspNetCore.Mvc;

namespace ITAM_DB.Controllers.Peripherals
{
    public class WebCamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
