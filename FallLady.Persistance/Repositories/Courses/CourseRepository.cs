using FallLady.Mood.Application.Contract.Dto.Course;
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
        public async Task<IEnumerable<FallLady.Mood.Domain.Domain.Courses.Course>> GetList(int skip = 0, int take = 10)
        {
            return await _dbContext.Courses
                                   .Include(x=> x.Teacher)
                                   .Include(x=> x.EventDays)
                                   .Include(x=> x.Category)
                                   .Include(x=> x.Tags)
                                   .Skip(take * skip)
                                   .Take(take)
                                   .AsNoTracking()
                                   .OrderByDescending(t => t.Id)
                                   .ToListAsync();
        }
        public Task<FallLady.Mood.Domain.Domain.Courses.Course> Get(int id)
        {
            var result = _dbContext.Courses
                                   .Include(x => x.Teacher)
                                   .Include(x => x.EventDays)
                                   .Include(x => x.Category)
                                   .Include(x => x.Tags)
                                   .FirstOrDefaultAsync(x=> x.Id == id);
            return result;
        }
    }
}
