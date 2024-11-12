using Microsoft.AspNetCore.Mvc;

namespace ITAM_DB.Controllers.Computers
{
    public class DesktopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
