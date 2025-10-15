using FallLady.Mood.Core.Enums;
using FallLady.Mood.Infrastructure.Utility.Service;
using FallLady.Mood.Models.DTO;
using FallLady.Mood.Models.ViewModels;
using FallLady.Mood.Services.Services.Impalement;
using FallLady.Mood.Services.Services.Interface;
using FallLady.Mood.UI.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using System.Drawing;

namespace FallLady.Mood.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : BaseController
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.ActivePage = "Courses";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoadAllCourses(int offset, int limit)
        {
            var dto = new CourseDto();
            dto.pageNumber = offset;
            dto.pageSize = limit;
            var data = await _courseService.Load(dto).ConfigureAwait(false);
            return Json(data);
        }

        [HttpGet]
        public virtual async Task<ActionResult> Create()
        {
            ViewBag.ActivePage = "Courses";

            var model = new CourseViewModel();

            ViewData["CourseTypes"] = EnumToList(typeof(CourseType), null);

            return PartialView("Create",model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseViewModel model)
        {
            model.CreateDate = DateTime.Now;
            if (!ModelState.IsValid)
            {
                var error = new ServiceResponse<bool>();
                error.SetException(GetErrorMessages());
                return Json(error);
            }
             
            if (model.OriginalImageFile != null &&
                model.OriginalImageFile.Length > 0)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(model.OriginalImageFile.FileName);
                string filePath = Path.Combine("wwwroot/Uploads/Course", model.OriginalImageFile.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    model.OriginalImageFile.CopyTo(fileStream);
                }
                model.OriginalImageName = fileName;


                Image image = Image.FromFile(fileName);
                Image thumb = image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
                thumb.Save(Path.ChangeExtension(fileName, "thumb"));
            }

            model.ThumbImageName = "null";
            var result = await _courseService.Save(model).ConfigureAwait(false);

            return Json(result);
        }

        [HttpGet]
        public virtual async Task<ActionResult> Edit(int? id)
        {
            ViewBag.ActivePage = "Courses";
            if (!id.HasValue)
                return RedirectToAction("Index");

            var model = await _courseService.Get(id.Value)
                                               .ConfigureAwait(false);
            if (model.ResultStatus != ResultStatus.Successful)
                return RedirectToAction("Index");

            ViewData["CourseTypes"] = EnumToList(typeof(CourseType), null);

            return PartialView("Create", model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CourseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var error = new ServiceResponse<bool>();
                error.SetException(GetErrorMessages());
                return Json(error);
            }

            if (model.OriginalImageFile != null &&
                model.OriginalImageFile.Length > 0)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(model.OriginalImageFile.FileName);
                string filePath = Path.Combine("wwwroot/Uploads/Course", model.OriginalImageFile.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    model.OriginalImageFile.CopyTo(fileStream);
                }
                model.OriginalImageName = fileName;


                Image image = Image.FromFile(fileName);
                Image thumb = image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
                thumb.Save(Path.ChangeExtension(fileName, "thumb"));
            }

            model.ThumbImageName = "null";
            var result = await _courseService.Save(model).ConfigureAwait(false);

            return Json(result);
        }
        public IActionResult Edit()
        {
            return View();
        }
    }
}
