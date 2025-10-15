using FallLady.Mood.Data.Domain;
using FallLady.Mood.Models.DTO;
using FallLady.Mood.Services.Repositories.Interface;
using FallLady.Mood.Services.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FallLady.Mood.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ManageUsersController : Controller
    {
        private readonly IUserService _userService;

        public ManageUsersController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            ViewBag.ActivePage = "ManageUsers";
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> LoadAllUsers(int offset, int limit)
        {
            var dto = new UserDto();
            dto.pageNumber = offset;
            dto.pageSize = limit;

            var data = await _userService.Load(dto).ConfigureAwait(false);
            return Json(data);
        }

        public IActionResult PromoteToAdmin(string userId)
        {
            return Json("");
        }
    }
}
