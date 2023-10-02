using FallLady.Mood.Domain.Enums;
using FallLady.Mood.Utility.Extentions;
using FallLady.Mood.Utility.Extentions.Datetime;

namespace FallLady.Mood.Application.Contract.Dto.Course
{
    public class CourseDetailsDto
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public CourseTypeEnum CourseType { get; set; }
        public string? CourseTypeTitle => CourseType.GetDisplayName();
        public Int64 Price { get; set; }
        public string Description { get; set; }

        public TimeOnly? FromTime { get; set; }
        public TimeOnly? ToTime { get; set; }

        public DateOnly? FromDate { get; set; }

        public DateOnly? ToDate { get; set; }

        public string? EventAddress { get; set; }

        public string ShortDescription { get; set; }
        public string CategoryTitle { get; set; }

        public string TeacherName { get; set; }
        public string TeacherFileName { get; set; }
        public string TeacherFilePath { get; set; }

        public Int64? DiscountPrice { get; set; }
        public Int64? DiscountPrecentage { get; set; }

        public string EventDays { get; set; }

        public string FilePath { get; set; }
        public string FileName { get; set; }

        public List<string> Tags { get; set; }

        public DateTime CreatedOn { get; set; }
        public string CreatedOnFa => CreatedOn.ToFa();

        public bool IsCurrentUserFavourite { get; set; }

    }
}
