using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Domain.Domain.Course.Exceptions
{
    public class CourseExceptions
    {
        public class TitleRequired : Exception
        {
            public TitleRequired(string message = "لطفا عنوان دوره را وارد کنید") : base(message)
            {

            }
        }
    }
}
