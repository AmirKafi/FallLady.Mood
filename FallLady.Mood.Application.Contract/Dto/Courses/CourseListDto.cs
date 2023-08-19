using FallLady.Mood.Domain.Enums;
using FallLady.Mood.Framework.Core.Enum;
using FallLady.Mood.Utility.Extentions;
using FallLady.Mood.Utility.Extentions.Datetime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Contract.Dto.Course
{
    public class CourseListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public CourseTypeEnum CourseType { get; set; }
        public string? CourseTypeTitle => CourseType.GetDisplayName();
        public float Price { get; set; }
        public string Description { get; set; }
        public TimeOnly? FromTime { get; set; }
        public TimeOnly? ToTime { get; set; }

        public DateOnly? FromDate { get; set; }

        public DateOnly? ToDate { get; set; }

        public string? EventAddress { get; set; }

        public string CategoryTitle { get; set; }
        public string TeacherName { get; set; }
        public string TeacherFileName { get; set; }
        public string TeacherFilePath { get; set; }

        public List<WeekDaysEnum> _eventDays { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
    }
}
