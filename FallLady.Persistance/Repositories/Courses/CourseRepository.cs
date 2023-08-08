using FallLady.Mood.Domain.Domain.Courses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Persistance.Repositories.Course
{
    public class CourseRepository : CrudRepository<FallLady.Mood.Domain.Domain.Courses.Course, int>, ICourseRepository
    {
        public Task<FallLady.Mood.Domain.Domain.Courses.Course> Get(int id)
        {
            var result = _dbContext.Courses.Include(x=> x.EventDays).FirstOrDefaultAsync(x=> x.Id == id);
            return result;
        }
    }
}
