using FallLady.Mood.Domain.Domain.Course.Exceptions;
using FallLady.Mood.Domain.Enums;
using FallLady.Mood.Framework.Core;
using FallLady.Mood.Framework.Core.Enum;
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
        public Course(string title,
                      CourseTypeEnum courseType,
                      float price,
                      string description,
                      string? licenseKey,
                      string fileName,
                      TimeOnly? fromTime,
                      TimeOnly? toTime,
                      DateOnly? fromDate,
                      DateOnly? toDate,
                      string? eventAddress,
                      List<WeekDaysEnum> eventDays)
        {
            Title = title;
            CourseType = courseType;
            Price = price;
            Description = description;
            FileName = fileName;

            if (courseType == CourseTypeEnum.Online)
            {
                LicenseKey = licenseKey;
                FromDate = null;
                ToDate = null;
                EventAddress = null;
                _eventDays = new List<CourseDays>();
            }
            else
            {
                LicenseKey = null;
                FromDate = fromDate?.ToDateTime(fromTime ?? default);
                ToDate = toDate?.ToDateTime(toTime ?? default);
                EventAddress = eventAddress;
                _eventDays = eventDays.Select(x => new CourseDays(this.Id, (int)x)).ToList();
            }
        }

        #region Properties
        public string Title { get; private set; }
        public CourseTypeEnum CourseType { get; private set; }
        public float Price { get; private set; }
        public string Description { get; private set; }
        public string? LicenseKey { get; private set; }
        public string FileName { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? EventAddress { get; set; }

        public List<CourseDays> _eventDays { get; set; } = new List<CourseDays>();
        public virtual IReadOnlyCollection<CourseDays> EventDays => _eventDays.AsReadOnly();
        #endregion

        #region Methods

        public Course Update(string title,
                             CourseTypeEnum courseType,
                             float price,
                             string description,
                             string? licenseKey,
                             string fileName,
                             TimeOnly? fromTime,
                             TimeOnly? toTime,
                             DateOnly? fromDate,
                             DateOnly? toDate,
                             string? eventAddress,
                             List<WeekDaysEnum> eventDays)
        {
            Title = title;
            CourseType = courseType;
            Price = price;
            Description = description;
            FileName = fileName;

            if (courseType == CourseTypeEnum.Online)
            {
                LicenseKey = licenseKey;
                FromDate = null;
                ToDate = null;
                EventAddress = null;
                _eventDays = new List<CourseDays>();
            }
            else
            {
                LicenseKey = null;
                FromDate = fromDate?.ToDateTime(fromTime ?? default);
                ToDate = toDate?.ToDateTime(toTime ?? default);
                EventAddress = eventAddress;
                _eventDays.Clear();
                _eventDays.AddRange(eventDays.Select(x => new CourseDays(this.Id, (int)x)).ToList());
            }
            return this;
        }

        #endregion
    }
}
