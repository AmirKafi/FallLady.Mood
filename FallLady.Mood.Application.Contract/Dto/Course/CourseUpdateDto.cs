using FallLady.Mood.Domain.Enums;
using System.ComponentModel;

namespace FallLady.Mood.Application.Contract.Dto.Course
{
    public class CourseUpdateDto
    {
        public int Id { get; set; }

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
    }

}
