using FallLady.Mood.Application.Contract.Dto.Users;
using FallLady.Mood.Application.Contract.Interfaces.Users;
using FallLady.Mood.Controllers.Base;
using FallLady.Mood.Framework.Core.Enum;
using Humanizer;
using Microsoft.AspNetCore.Mvc;

namespace FallLady.Mood.Controllers
{
    public class AccountController : BaseController
    {
        #region Constructor
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/Login")]
        public async Task<ActionResult> Login()
        {
            return PartialView();
        }

        [HttpPost]
        [Route("/Login")]
        public async Task<ActionResult> Login(UserLoginDto dto)
        {
            var user = await _userService.Login(dto.UserName, dto.Password);
            return Json(user);
        }

        [HttpGet]
        [Route("/Register")]
        public async Task<ActionResult> Register()
        {
            return PartialView();
        }

        [HttpPost]
        [Route("/Register")]
        public async Task<ActionResult> Register(UserCreateDto dto)
        {
            dto.Role = RoleEnum.User;
            dto.IsActive = true;

            var user = await _userService.AddUser(dto);
            return Json(user);
        }
    }
}
