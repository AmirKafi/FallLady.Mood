using FallLady.Mood.Application.Contract.Dto;
using FallLady.Mood.Application.Contract.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FallLady.Mood.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {

        [Route("/Admin/Index")]
        public async Task<ActionResult> Index()
        {
            return View();
        }
    }
}
