using Microsoft.AspNetCore.Mvc;

namespace ITAM_DB.Controllers.Computers
{
    public class LaptopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
