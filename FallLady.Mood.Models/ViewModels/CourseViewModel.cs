using FallLady.Mood.Core.Enums;
using FallLady.Mood.Core.Utilities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FallLady.Mood.Models.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        [Display(Name = "عنوان دوره")]
        [Required(ErrorMessage = "فیلد {0} اجباری است")]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "تصویر دوره")]
        [Required(ErrorMessage = "فیلد {0} اجباری است")]
        public IFormFile OriginalImageFile { get; set; }

        public string? OriginalImageName { get; set; }

        public string? ThumbImageName { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "فیلد {0} اجباری است")]
        public int Price { get; set; }


        [Display(Name = "نوع دوره")]
        [Required(ErrorMessage = "فیلد {0} اجباری است")]
        public CourseType CourseType { get; set; }

        public string CourseTypeTitle => EnumDisplayValueConverter.GetEnumDisplayValue(CourseType);

        [Display(Name = "شناسه لایسنس")]
        public string LicenseId { get; set; }

        public DateTime CreateDate { get; set; }

    }
}
