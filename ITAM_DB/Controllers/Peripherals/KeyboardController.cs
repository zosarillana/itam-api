using Microsoft.AspNetCore.Mvc;

namespace ITAM_DB.Controllers.Peripherals
{
    public class KeyboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
