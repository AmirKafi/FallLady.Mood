using FallLady.Mood.Application.Contract.Dto.Users;
using FallLady.Mood.Application.Contract.Interfaces.Orders;
using FallLady.Mood.Application.Contract.Interfaces.Users;
using FallLady.Mood.Controllers.Base;
using FallLady.Mood.Domain.Domain.Users;
using FallLady.Mood.Framework.Core.Enum;
using FallLady.Mood.Utility.ServiceResponse;
using Microsoft.AspNetCore.Mvc;

namespace FallLady.Mood.Controllers
{
    public class UserProfileController : BaseController
    {
        #region Constructor
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;

        public UserProfileController(IUserService userService, IOrderService orderService)
        {
            _userService = userService;
            _orderService = orderService;
        }

        #endregion
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> UserSetting()
        {
            ViewBag.ActivePage = "UserSetting";

            var userId = await _userService.GetUserId(User).ConfigureAwait(false);

            var model = await _userService.GetUser(userId.Data).ConfigureAwait(false);

            return View(model.Data);
        }

        [HttpPost]
        public async Task<ActionResult> UserSetting(UserUpdateDto dto)
        {
            ViewBag.ActivePage = "UserSetting";

            var user = await _userService.GetUser(dto.Id).ConfigureAwait(false);
            dto.Role = user.Data.Role;
            dto.IsActive= user.Data.IsActive;

            var result = await _userService.UpdateUser(dto).ConfigureAwait(false);

            return Json(result);
        }

        [HttpGet]
        public IActionResult UserFavourites()
        {
            return View();
        }

        public async Task<ActionResult> UserCourses()
        {
            ViewBag.ActivePage = "UserCourses";
            var userId = await _userService.GetUserId(User);
            var orders = await _orderService.LoadPaidOrders(userId.Data);
            if (orders.ResultStatus == ResultStatus.Successful)
                orders.Data.ForEach(x => x.Course.FilePath = GetFileUrl(x.Course.FileName, FileFoldersEnum.Course));

            return View(orders.Data);
        }
    }
}
