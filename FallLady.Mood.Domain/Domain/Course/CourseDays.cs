using FallLady.Mood.Framework.Core;
using FallLady.Mood.Framework.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Domain.Domain.Course
{
    public class CourseDays:EntityId<int>
    {
        private CourseDays()
        {

        }
        public CourseDays(int courseId, int weekDayId)
        {
            CourseId = courseId;
            WeekDayId = weekDayId;
        }

        public int CourseId { get; set; }
        public int WeekDayId { get; set; }

        public virtual WeekDaysEnum WeekDay { get; set; }
        public virtual Course Course { get; set; }
    }
}
