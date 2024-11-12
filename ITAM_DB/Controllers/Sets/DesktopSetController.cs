using Microsoft.AspNetCore.Mvc;

namespace ITAM_DB.Controllers.Sets
{
    public class DesktopSetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
