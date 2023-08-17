using FallLady.Mood.Application.Contract.Dto;
using FallLady.Mood.Application.Contract.Interfaces;
using FallLady.Mood.Application.Contract.Interfaces.Teachers;
using FallLady.Mood.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FallLady.Mood.Controllers
{
    public class HomeController : Controller
    {
        #region Constructor
        private readonly ICategoryService _categoryService;
        private readonly ITeacherService _teacherService;

        public HomeController(ICategoryService categoryService, ITeacherService teacherService)
        {
            _categoryService = categoryService;
            _teacherService = teacherService;
        }
        #endregion

        public async Task<ActionResult> Index()
        {
            var model = new HomeItemsDto();

            //Category
            var category = await _categoryService.LoadCategories().ConfigureAwait(false);
            model.Categories = category.Data;


            //Teacher
            var teacher = await _teacherService.LoadTeachers().ConfigureAwait(false);
            model.Teachers = teacher.Data;

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}