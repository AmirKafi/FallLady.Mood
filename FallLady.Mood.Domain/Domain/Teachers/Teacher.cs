using FallLady.Mood.Domain.Domain.Courses;
using FallLady.Mood.Domain.Enums;
using FallLady.Mood.Framework.Core;
using FallLady.Mood.Framework.Core.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FallLady.Mood.Domain.Domain.Teachers
{
    public class Teacher:EntityId<int>
    {
        private Teacher()
        {
            
        }
        public Teacher(string fullName)
        {

            FullName = fullName;
        }

        public string FullName { get; set; }

        public ICollection<Course> Courses { get; set; }

        public Teacher Update(string fullName)
        {
            FullName = fullName;
            return this;
        }
    }
}
