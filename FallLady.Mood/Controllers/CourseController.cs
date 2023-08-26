using FallLady.Mood.Application.Contract.Dto.Course;
using FallLady.Mood.Application.Contract.Interfaces.Course;
using FallLady.Mood.Controllers.Base;
using FallLady.Mood.Domain.Enums;
using FallLady.Mood.Framework.Core.Enum;
using FallLady.Mood.Utility.Extentions;
using Microsoft.AspNetCore.Mvc;

namespace FallLady.Mood.Controllers
{
    public class CourseController : BaseController
    {
        #region Constructor
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        #endregion

        [Route("/OfflineCourses")]
        public async Task<ActionResult> OfflineCourses(CourseDto dto)
        {
            dto.CourseType = CourseTypeEnum.Offline;
            dto.limit = 100;
            dto.offset = 0;

            var courses = await _courseService.LoadCourses(dto).ConfigureAwait(false);
            courses.Data.ForEach(x => x.FilePath = GetFileUrl(x.FileName, FileFoldersEnum.Course));
            courses.Data.ForEach(x => x.TeacherFilePath = GetFileUrl(x.TeacherFileName, FileFoldersEnum.Teacher));

            ViewBag.CourseType = dto.CourseType;
            return View("Index", courses.Data);
        }

        [Route("/OnlineCourses")]
        public async Task<ActionResult> OnlineCourses(CourseDto dto)
        {
            dto.CourseType = CourseTypeEnum.Online;
            dto.limit = 100;
            dto.offset = 0;

            var courses = await _courseService.LoadCourses(dto).ConfigureAwait(false);
            courses.Data.ForEach(x => x.FilePath = GetFileUrl(x.FileName, FileFoldersEnum.Course));
            courses.Data.ForEach(x => x.TeacherFilePath = GetFileUrl(x.TeacherFileName, FileFoldersEnum.Teacher));

            ViewBag.CourseType = dto.CourseType;
            return View("Index", courses.Data);
        }
    }
}
