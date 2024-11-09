using Microsoft.AspNetCore.Mvc;

namespace ITAM_DB.Controllers.Peripherals
{
    public class MouseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
