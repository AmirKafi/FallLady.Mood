using FallLady.Mood.Domain.Domain.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Persistance.Repositories.Course
{
    public class CourseRepository : CrudRepository<FallLady.Mood.Domain.Domain.Course.Course, int>, ICourseRepository
    {

    }
}
