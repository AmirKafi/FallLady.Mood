using FallLady.Mood.Domain.Enums;
using FallLady.Mood.Utility.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Contract.Dto.Course
{
    public class CourseListDto
    {
        public string Title { get; set; }
        public CourseTypeEnum CourseType { get; set; }
        public string? CourseTypeTitle => CourseType.GetDisplayName();
        public float Price { get; set; }
        public string Description { get; set; }
    }
}
