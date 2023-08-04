using FallLady.Mood.Domain.Enums;
using FallLady.Mood.Framework.Core.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FallLady.Mood.Application.Contract.Dto.Course
{
    public class CourseCreateDto
    {
        [DisplayName("عنوان دوره")]
        [Required(ErrorMessage = "این فیلد اجباری می باشد")]
        public string? Title { get; set; }

        [DisplayName("نوع")]
        [Required(ErrorMessage = "این فیلد اجباری می باشد")]
        public CourseTypeEnum? CourseType { get; set; }

        [DisplayName("مبلغ")]
        [Required(ErrorMessage = "این فیلد اجباری می باشد")]
        public float? Price { get; set; }

        [DisplayName("توضیحات")]
        [Required(ErrorMessage = "این فیلد اجباری می باشد")]
        public string? Description { get; set; }

        [DisplayName("کد لایسنس")]
        public string? LicenseKey { get; set; }

        [DisplayName("تصویر")]
        public string FileName { get; set; }
        public IFormFile File { get; set; }

        [DisplayName("از ساعت")]
        public TimeOnly? FromTime { get; set; }

        [DisplayName("تا ساعت")]
        public TimeOnly? ToTime { get; set; }

        [DisplayName("از تاریخ")]
        public string FromDateLocal { get; set; }
        public DateOnly? FromDate { get; set; }

        [DisplayName("تا تاریخ")]
        public string ToDateLocal { get; set; }
        public DateOnly? ToDate { get; set; }

        [DisplayName("محل برگزاری")]
        public string? EventAddress { get; set; }

        [DisplayName("روز های برگزاری")]
        public List<WeekDaysEnum> EventDays { get; set; }
    }

}
