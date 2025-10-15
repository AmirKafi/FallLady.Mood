using Microsoft.AspNetCore.Mvc;

namespace FallLady.Mood.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        [Route("/Admin/Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
