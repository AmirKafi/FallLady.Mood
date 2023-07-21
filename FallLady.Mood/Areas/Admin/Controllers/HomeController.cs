using Microsoft.AspNetCore.Mvc;

namespace FallLady.Mood.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
