using FallLady.Mood.Application.Contract.Dto;
using FallLady.Mood.Application.Contract.Dto.Blogs;
using FallLady.Mood.Application.Contract.Dto.Users;
using FallLady.Mood.Application.Contract.Interfaces.Blogs;
using FallLady.Mood.Application.Contract.Interfaces.Categories;
using FallLady.Mood.Application.Contract.Interfaces.Configs;
using FallLady.Mood.Application.Contract.Interfaces.Course;
using FallLady.Mood.Application.Contract.Interfaces.Teachers;
using FallLady.Mood.Application.Contract.Interfaces.Users;
using FallLady.Mood.Application.Services.Users;
using FallLady.Mood.Controllers.Base;
using FallLady.Mood.Framework.Core.Enum;
using FallLady.Mood.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FallLady.Mood.Controllers
{
    public class HomeController : BaseController
    {
        #region Constructor
        private readonly ICategoryService _categoryService;
        private readonly ITeacherService _teacherService;
        private readonly ICourseService _courseService;
        private readonly IUserService _userService;
        private readonly IBlogService _blogService;
        private readonly IConfigService _configService;

        public HomeController(ICategoryService categoryService,
                              ITeacherService teacherService,
                              ICourseService courseService, 
                              IUserService userService, 
                              IBlogService blogService,
                              IConfigService configService)
        {
            _categoryService = categoryService;
            _teacherService = teacherService;
            _courseService = courseService;
            _userService = userService;
            _blogService = blogService;
            _configService = configService;
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
            model.Courses.ForEach(x => x.FilePath = GetFileUrl(x.FileName, FileFoldersEnum.Course));
            model.Courses.ForEach(x => x.TeacherFilePath = GetFileUrl(x.TeacherFileName, FileFoldersEnum.Teacher));


            //Teacher
            var teacher = await _teacherService.LoadTeachers().ConfigureAwait(false);
            model.Teachers = teacher.Data;
            model.Teachers.ForEach(x => x.FilePath = GetFileUrl(x.FileName, FileFoldersEnum.Teacher));


            //Blog
            var blogs = await _blogService.LoadBlogs(new BlogDto() { limit = 6, offset = 0 }).ConfigureAwait(false);
            model.Blogs = blogs.Data;
            model.Blogs.ForEach(x => x.PicturePath = GetFileUrl(x.Picture, FileFoldersEnum.Blog));

            return View(model);
        }

        [Route("/ContactUs")]
        public async Task<ActionResult> ContectUs()
        {
            var model = await _configService.GetConfig().ConfigureAwait(false);

            return View(model.Data);
        }
    }
}