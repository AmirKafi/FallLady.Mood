﻿using FallLady.Mood.Application.Contract.Dto.Teacher;
using FallLady.Mood.Application.Contract.Interfaces.Teachers;
using FallLady.Mood.Controllers.Base;
using FallLady.Mood.Domain.Enums;
using FallLady.Mood.Framework.Core.Enum;
using FallLady.Mood.Utility.ServiceResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FallLady.Mood.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TeacherController : BaseController
    {

        #region Constrcutor
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService TeacherService)
        {
            _teacherService = TeacherService;
        }

        #endregion

        [Route("/Teacher/Index")]
        public IActionResult Index()
        {
            ViewBag.ActivePage = "Teacher";

            return View();
        }

        [Route("/Teacher/LoadTeachers")]
        public async Task<ActionResult> LoadTeachers(TeacherDto dto)
        {
            var data = await _teacherService.LoadTeachers(dto).ConfigureAwait(false);

            return Json(data);
        }

        [HttpGet]
        [Route("/Teacher/Create")]
        public async Task<ActionResult> Create()
        {
            ViewBag.ActivePage = "Teacher";
            var model = new TeacherCreateDto();

            return PartialView("Create", model);
        }

        [HttpPost]
        [Route("/Teacher/Create")]
        public async Task<ActionResult> Create(TeacherCreateDto dto)
        {
            ViewBag.ActivePage = "Teacher";


            var result = await _teacherService.AddTeacher(dto).ConfigureAwait(false);

            return Json(result);
        }

        [HttpGet]
        [Route("/Teacher/Edit")]
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.ActivePage = "Teacher";

            var Teacher = await _teacherService.GetTeacher(id).ConfigureAwait(false);
            if (Teacher.ResultStatus != ResultStatus.Successful)
            {
                Teacher.SetException("GetDataFailed");
                return Json(Teacher);
            }

            var model = Teacher.Data;

            return PartialView("Edit", model);
        }

        [HttpPost]
        [Route("/Teacher/Edit")]
        public async Task<ActionResult> Edit(TeacherUpdateDto dto)
        {
            ViewBag.ActivePage = "Teacher";

            var result = await _teacherService.UpdateTeacher(dto).ConfigureAwait(false);

            return Json(result);
        }

        [HttpPost]
        [Route("/Teacher/Delete")]
        public async Task<ActionResult> Delete(List<int> ids)
        {
            ViewBag.ActivePage = "Teacher";

            var result = await _teacherService.Delete(ids[0]).ConfigureAwait(false);

            return Json(result);
        }
    }
}
