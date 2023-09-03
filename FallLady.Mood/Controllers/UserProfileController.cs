using FallLady.Mood.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace FallLady.Mood.Controllers
{
    public class UserProfileController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
