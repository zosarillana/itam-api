using Microsoft.AspNetCore.Mvc;

namespace ITAM_DB.Controllers.Peripherals
{
    public class BagController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
