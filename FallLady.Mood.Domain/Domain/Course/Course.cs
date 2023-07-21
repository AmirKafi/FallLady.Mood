using FallLady.Mood.Domain.Domain.Course.Exceptions;
using FallLady.Mood.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Domain.Domain.Course
{
    public class Course : EntityId<int>
    {
        private Course()
        {

        }
        public Course(string title, CourseTypeEnum courseType, float price, string description, string licenseKey)
        {
            Title = title;
            CourseType = courseType;
            Price = price;
            Description = description;
            LicenseKey = licenseKey;
        }

        #region Properties
        public string Title { get; private set; }
        public CourseTypeEnum CourseType { get; private set; }
        public float Price { get; private set; }
        public string Description { get; private set; }
        public string LicenseKey { get; private set; }

        #endregion

        #region Guards

        private static void GuardAgainstTitleBeingNullOrEmptyOrSpace(string title)
        {
            if (string.IsNullOrEmpty(title) || title.Trim() == "")
                throw new CourseExceptions.TitleRequired();
        }

        private static void GuardAgainstCourseTypeBeingNullOrEmptyOrSpace(string title)
        {
            if (string.IsNullOrEmpty(title) || title.Trim() == "")
                throw new CourseExceptions.TitleRequired();
        }

        #endregion
    }
}
