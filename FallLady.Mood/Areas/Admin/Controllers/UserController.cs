﻿using FallLady.Mood.Application.Contract.Interfaces.Teachers;
using FallLady.Mood.Controllers.Base;
using FallLady.Mood.Domain.Enums;
using FallLady.Mood.Framework.Core.Enum;
using FallLady.Mood.Utility.ServiceResponse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FallLady.Mood.Application.Contract.Interfaces.Users;
using FallLady.Mood.Application.Contract.Dto.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace FallLady.Mood.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UserController : BaseController
    {
        #region Constrcutor
        private readonly IUserService _UserService;

        public UserController(IUserService UserService)
        {
            _UserService = UserService;
        }

        #endregion

        [Route("/User/Index")]
        public IActionResult Index()
        {
            ViewBag.ActivePage = "User";

            return View();
        }

        [Route("/User/LoadUsers")]
        public async Task<ActionResult> LoadUsers(UserDto dto)
        {
            var data = await _UserService.LoadUsers(dto).ConfigureAwait(false);
            return Json(data);
        }

        [HttpGet]
        [Route("/User/Create")]
        public async Task<ActionResult> Create()
        {
            ViewBag.ActivePage = "User";
            var model = new UserCreateDto();
            ViewBag.Roles = EnumToList(typeof(RoleEnum), null);
            ((List<SelectListItem>)(ViewBag.Roles)).Insert(0, new SelectListItem());

            return PartialView("Create", model);
        }

        [HttpPost]
        [Route("/User/Create")]
        public async Task<ActionResult> Create(UserCreateDto dto)
        {
            ViewBag.ActivePage = "User";

            var result = new ServiceResponse<IdentityResult>();

            result = await _UserService.AddUser(dto).ConfigureAwait(false);

            return Json(result);
        }

        [HttpGet]
        [Route("/User/Edit")]
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.ActivePage = "User";

            var User = await _UserService.GetUser(id).ConfigureAwait(false);
            if (User.ResultStatus != ResultStatus.Successful)
            {
                User.SetException("GetDataFailed");
                return Json(User);
            }

            var model = User.Data;
            ViewBag.Roles = EnumToList(typeof(RoleEnum), null);
            ((List<SelectListItem>)(ViewBag.Roles)).Insert(0, new SelectListItem());

            return PartialView("Edit", model);
        }

        [HttpPost]
        [Route("/User/Edit")]
        public async Task<ActionResult> Edit(UserUpdateDto dto)
        {
            ViewBag.ActivePage = "User";

            var result = new ServiceResponse<bool>();

            result = await _UserService.UpdateUser(dto).ConfigureAwait(false);

            return Json(result);
        }

        [HttpPost]
        [Route("/User/Delete")]
        public async Task<ActionResult> Delete(List<int> ids)
        {
            ViewBag.ActivePage = "User";

            var result = await _UserService.Delete(ids[0]).ConfigureAwait(false);

            return Json(result);
        }

        [HttpPost]
        [Route("/User/PromoteToAdmin")]
        public async Task<ActionResult> PromoteToAdmin(int id)
        {
            var user = await _UserService.GetUser(id).ConfigureAwait(false);

            user.Data.Role = RoleEnum.Admin;

            var result = await _UserService.UpdateUser(user.Data).ConfigureAwait(false);

            return Json(result);
        }
    }
}
