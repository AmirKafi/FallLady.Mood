using FallLady.Mood.Application.Contract.Dto.Course;
using FallLady.Mood.Application.Contract.Interfaces;
using FallLady.Mood.Controllers.Base;
using FallLady.Mood.Domain.Enums;
using FallLady.Mood.Framework.Core.Enum;
using FallLady.Mood.Utility.ServiceResponse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FallLady.Mood.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : BaseController
    {
        #region Constrcutor
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        #endregion

        [Route("/Course/Index")]
        public IActionResult Index()
        {
            ViewBag.ActivePage = "Course";

            return View();
        }

        [Route("/Course/LoadCourses")]
        public async Task<ActionResult> LoadCourses(CourseDto dto)
        {
            var data =await _courseService.LoadCourses(dto).ConfigureAwait(false);
            data.Data.ForEach(x=> x.FilePath = GetFileUrl(x.FileName,FileFoldersEnum.Course));

            return Json(data);
        }

        [HttpGet]
        [Route("/Course/Create")]
        public async Task<ActionResult> Create()
        {
            ViewBag.ActivePage = "Course" ;
            var model = new CourseCreateDto();
            model.CourseTypes = EnumToList(typeof(CourseTypeEnum), null);
            model.CourseTypes.Insert(0, new SelectListItem());

            return PartialView("Create",model);
        }

        [HttpPost]
        [Route("/Course/Create")]
        public async Task<ActionResult> Create(CourseCreateDto dto)
        {
            ViewBag.ActivePage = "Course";

            if(dto.File is null)
            {
                var res = new ServiceResponse<bool>();
                res.SetException("انتخاب تصویر اجباری می باشد");
                return Json(res);
            }

            var fileName = SaveFile(dto.File, FileFoldersEnum.Course);
            dto.FileName = fileName.Data;
            var result = await _courseService.AddCourse(dto).ConfigureAwait(false);

            return Json(result);
        }

        [HttpGet]
        [Route("/Course/Edit")]
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.ActivePage = "Course";

            var course = await _courseService.GetCourse(id).ConfigureAwait(false);

            var model = course.Data;
            model.FilePath = GetFileUrl(model.FileName, FileFoldersEnum.Course);
            model.CourseTypes = EnumToList(typeof(CourseTypeEnum), null);
            model.CourseTypes.Insert(0, new SelectListItem());

            return PartialView("Edit", model);
        }

        [HttpPost]
        [Route("/Course/Edit")]
        public async Task<ActionResult> Edit(CourseUpdateDto dto)
        {
            ViewBag.ActivePage = "Course";

            if (dto.File is null)
            {
                var res = new ServiceResponse<bool>();
                res.SetException("انتخاب تصویر اجباری می باشد");
                return Json(res);
            }

            var fileName = SaveFile(dto.File, FileFoldersEnum.Course);
            dto.FileName = fileName.Data;
            var result = await _courseService.UpdateCourse(dto).ConfigureAwait(false);

            return Json(result);
        }
    }
}
