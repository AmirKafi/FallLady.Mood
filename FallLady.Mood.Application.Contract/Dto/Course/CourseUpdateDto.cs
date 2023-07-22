using FallLady.Mood.Domain.Enums;

namespace FallLady.Mood.Application.Contract.Dto.Course
{
    public class CourseUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public CourseTypeEnum CourseType { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string LicenseKey { get; set; }
    }

}
