using FallLady.Mood.Domain.Enums;
using FallLady.Mood.Utility.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Contract.Dto.Course
{
    public class CourseDto:BaseDto
    {
        public int? TeacherId { get; set; }
        public int? CategoryId { get; set; }
        public string? Title { get; set; }
        public CourseTypeEnum? CourseType { get; set; }
        public float? Price { get; set; }
        public string? Description { get; set; }
    }

}
