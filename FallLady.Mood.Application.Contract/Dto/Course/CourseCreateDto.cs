using FallLady.Mood.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FallLady.Mood.Application.Contract.Dto.Course
{
    public class CourseCreateDto
    {
        [DisplayName("عنوان دوره")]
        public string Title { get; set; }

        [DisplayName("نوع")]
        public CourseTypeEnum CourseType { get; set; }

        [DisplayName("مبلغ")]
        public float Price { get; set; }

        [DisplayName("توضیحات")]
        public string Description { get; set; }

        [DisplayName("کد لایسنس")]
        public string LicenseKey { get; set; }

        public List<SelectListItem> CourseTypes { get; set; }
    }

}
