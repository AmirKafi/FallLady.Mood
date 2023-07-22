using FallLady.Mood.Domain.Domain.Course.Exceptions;
using FallLady.Mood.Domain.Enums;
using FallLady.Mood.Framework.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        #region Methods

        public Course Update(string title, CourseTypeEnum courseType, float price, string description, string licenseKey)
        {
            Title = title;
            CourseType = courseType;
            Price = price;
            Description = description;
            LicenseKey = licenseKey;

            return this;
        }

        #endregion
    }
}
