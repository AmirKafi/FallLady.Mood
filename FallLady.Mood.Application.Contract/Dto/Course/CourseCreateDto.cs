using FallLady.Mood.Domain.Enums;

namespace FallLady.Mood.Application.Contract.Dto.Course
{
    public class CourseCreateDto
    {
        public string Title { get; set; }
        public CourseTypeEnum CourseType { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string LicenseKey { get; set; }
    }

}
