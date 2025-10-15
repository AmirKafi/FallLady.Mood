using FallLady.Mood.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Data.Domain
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string OriginalImageName { get; set; }
        public string ThumbImageName { get; set; }
        public int Price { get; set; }
        public CourseType CourseType { get; set; }
        public string? LicenseId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
