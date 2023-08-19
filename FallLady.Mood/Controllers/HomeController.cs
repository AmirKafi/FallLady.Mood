using FallLady.Mood.Application.Contract.Dto;
using FallLady.Mood.Application.Contract.Interfaces;
using FallLady.Mood.Application.Contract.Interfaces.Course;
using FallLady.Mood.Application.Contract.Interfaces.Teachers;
using FallLady.Mood.Controllers.Base;
using FallLady.Mood.Framework.Core.Enum;
using FallLady.Mood.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FallLady.Mood.Controllers
{
    public class HomeController : BaseController
    {
        #region Constructor
        private readonly ICategoryService _categoryService;
        private readonly ITeacherService _teacherService;
        private readonly ICourseService _courseService;

        public HomeController(ICategoryService categoryService, ITeacherService teacherService, ICourseService courseService)
        {
            _categoryService = categoryService;
            _teacherService = teacherService;
            _courseService = courseService;
        }
        #endregion

        public async Task<ActionResult> Index()
        {
            var model = new HomeItemsDto();

            //Category
            var category = await _categoryService.LoadCategories().ConfigureAwait(false);
            model.Categories = category.Data;


            //Courses
            var courses = await _courseService.LoadCourses().ConfigureAwait(false);
            model.Courses = courses.Data;
            model.Courses.ForEach(x=> x.FilePath = GetFileUrl(x.FileName,FileFoldersEnum.Course));
            model.Courses.ForEach(x=> x.TeacherFilePath = GetFileUrl(x.TeacherFileName,FileFoldersEnum.Teacher));


            //Teacher
            var teacher = await _teacherService.LoadTeachers().ConfigureAwait(false);
            model.Teachers = teacher.Data;
            model.Teachers.ForEach(x => x.FilePath = GetFileUrl(x.FileName, FileFoldersEnum.Teacher));

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}