using Microsoft.AspNetCore.Mvc;

namespace ITAM_DB.Controllers.Cards
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : Controller
    {       
        public IActionResult Index()
        {
            return View();
        }
    }
}
