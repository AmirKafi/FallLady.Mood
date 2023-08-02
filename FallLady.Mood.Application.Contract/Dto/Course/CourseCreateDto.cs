using FallLady.Mood.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FallLady.Mood.Application.Contract.Dto.Course
{
    public class CourseCreateDto
    {
        [DisplayName("عنوان دوره")]
        [Required(ErrorMessage = "فیلد عنوان دوره اجباری می باشد")]
        public string? Title { get; set; }

        [DisplayName("نوع")]
        [Required(ErrorMessage = "فیلد عنوان دوره اجباری می باشد")]
        public CourseTypeEnum? CourseType { get; set; }

        [DisplayName("مبلغ")]
        [Required(ErrorMessage = "فیلد عنوان دوره اجباری می باشد")]
        public float? Price { get; set; }

        [DisplayName("توضیحات")]
        [Required(ErrorMessage = "فیلد عنوان دوره اجباری می باشد")]
        public string? Description { get; set; }

        [DisplayName("کد لایسنس")]
        [Required(ErrorMessage = "فیلد عنوان دوره اجباری می باشد")]
        public string? LicenseKey { get; set; }

        public List<SelectListItem> CourseTypes { get; set; }
    }

}
