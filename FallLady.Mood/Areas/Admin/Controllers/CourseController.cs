using FallLady.Mood.Application.Contract.Dto.Course;
using FallLady.Mood.Application.Contract.Interfaces;
using FallLady.Mood.Controllers.Base;
using FallLady.Mood.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

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
            var model =await _courseService.LoadCourses(dto).ConfigureAwait(false);
            return Json(model);
        }

        [Route("/Course/Create")]
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ViewBag.ActivePage = "Course" ;
            var model = new CourseCreateDto();
            model.CourseTypes = EnumToList(typeof(CourseTypeEnum), null);

            return PartialView("Create",model);
        }
    }
}
