using FallLady.Mood.Application.Contract.Dto.Course;
using FallLady.Mood.Application.Contract.Interfaces.Course;
using FallLady.Mood.Controllers.Base;
using FallLady.Mood.Domain.Enums;
using FallLady.Mood.Framework.Core.Enum;
using FallLady.Mood.Utility.Extentions.Datetime;
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
            if(data.ResultStatus == ResultStatus.Successful)
                data.Data.ForEach(x => x.FilePath = GetFileUrl(x.FileName, FileFoldersEnum.Course));

            return Json(data);
        }

        [HttpGet]
        [Route("/Course/Create")]
        public async Task<ActionResult> Create()
        {
            ViewBag.ActivePage = "Course" ;
            var model = new CourseCreateDto();

            ViewBag.EventDaysList = EnumToList(typeof(WeekDaysEnum), null, false);
            ViewBag.CourseTypes = EnumToList(typeof(CourseTypeEnum), null);
            ((List<SelectListItem>)ViewBag.EventDaysList).Insert(0, new SelectListItem());
            ((List<SelectListItem>)ViewBag.CourseTypes).Insert(0, new SelectListItem());

            return PartialView("Create",model);
        }

        [HttpPost]
        [Route("/Course/Create")]
        public async Task<ActionResult> Create(CourseCreateDto dto)
        {
            ViewBag.ActivePage = "Course";

            var result = new ServiceResponse<bool>();

            if (dto.File is null)
            {
                var res = new ServiceResponse<bool>();
                res.SetException("انتخاب تصویر اجباری می باشد");
                return Json(res);
            }
            if (dto.CourseType == CourseTypeEnum.Online && dto.LicenseKey is null)
            {
                result.SetException("فیلد کد لایسنس اجباری می باشد");
                return Json(result);
            }
            else
            {
                if (dto.EventDays is null)
                    ModelState.AddModelError("", "انتخاب روز های برگزاری اجباری می باشد");
                if (dto.FromTime is null)
                    ModelState.AddModelError("", "فیلد از ساعت اجباری می باشد");
                if (dto.ToTime is null)
                    ModelState.AddModelError("", "فیلد تا ساعت اجباری می باشد");
                if (dto.FromDateLocal is null)
                    ModelState.AddModelError("", "فیلد از تاریخ اجباری می باشد");
                if (dto.ToDateLocal is null)
                    ModelState.AddModelError("", "فیلد تا تاریخ اجباری می باشد");
                if (!ModelState.IsValid)
                {
                    result.SetException(GetErrorMessages());
                    return Json(result);
                }
                dto.FromDate = dto.FromDateLocal.ToEn().AsDateOnly();
                dto.ToDate = dto.ToDateLocal.ToEn().AsDateOnly();
            }

            var fileName = SaveFile(dto.File, FileFoldersEnum.Course);
            dto.FileName = fileName.Data;
            result = await _courseService.AddCourse(dto).ConfigureAwait(false);

            return Json(result);
        }

        [HttpGet]
        [Route("/Course/Edit")]
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.ActivePage = "Course";

            var course = await _courseService.GetCourse(id).ConfigureAwait(false);
            if(course.ResultStatus != ResultStatus.Successful)
            {
                course.SetException("GetDataFailed");
                return Json(course);
            }

            var model = course.Data;
            model.FilePath = GetFileUrl(model.FileName, FileFoldersEnum.Course);
            if(model.CourseType == CourseTypeEnum.Offline)
            {
                model.FromDateLocal = model.FromDate.AsDateTime().ToFa();
                model.ToDateLocal = model.ToDate.AsDateTime().ToFa();
            }


            ViewBag.EventDaysList = EnumToList(typeof(WeekDaysEnum), null, false);
            ViewBag.CourseTypes = EnumToList(typeof(CourseTypeEnum), null);
            ((List<SelectListItem>)ViewBag.EventDaysList).Insert(0, new SelectListItem());
            ((List<SelectListItem>)ViewBag.CourseTypes).Insert(0, new SelectListItem());

            return PartialView("Edit", model);
        }

        [HttpPost]
        [Route("/Course/Edit")]
        public async Task<ActionResult> Edit(CourseUpdateDto dto)
        {
            ViewBag.ActivePage = "Course";

            var result = new ServiceResponse<bool>();

            if(dto.File != null)
            {
                var fileName = SaveFile(dto.File, FileFoldersEnum.Course);
                dto.FileName = fileName.Data;
            }
            if (dto.CourseType == CourseTypeEnum.Online && dto.LicenseKey is null)
            {
                result.SetException("فیلد کد لایسنس اجباری می باشد");
                return Json(result);
            }
            else
            {
                if (dto.EventDays is null)
                    ModelState.AddModelError("","انتخاب روز های برگزاری اجباری می باشد");
                if(dto.FromTime is null)
                    ModelState.AddModelError("", "فیلد از ساعت اجباری می باشد");
                if(dto.ToTime is null)
                    ModelState.AddModelError("", "فیلد تا ساعت اجباری می باشد");
                if(dto.FromDateLocal is null)
                    ModelState.AddModelError("", "فیلد از تاریخ اجباری می باشد");
                if(dto.ToDateLocal is null)
                    ModelState.AddModelError("", "فیلد تا تاریخ اجباری می باشد");
                if (!ModelState.IsValid)
                {
                    result.SetException(GetErrorMessages());
                    return Json(result);
                }
                dto.FromDate = dto.FromDateLocal.ToEn().AsDateOnly();
                dto.ToDate = dto.ToDateLocal.ToEn().AsDateOnly();
            }

            result = await _courseService.UpdateCourse(dto).ConfigureAwait(false);

            return Json(result);
        }

        [HttpPost]
        [Route("/Course/Delete")]
        public async Task<ActionResult> Delete(List<int> ids)
        {
            ViewBag.ActivePage = "Course";

            var result = await _courseService.Delete(ids[0]).ConfigureAwait(false);

            return Json(result);
        }
    }
}
