using Microsoft.AspNetCore.Mvc;

namespace ITAM_DB.Controllers.Peripherals
{
    public class DongleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
