using FallLady.Mood.Domain.Domain.Tags;
using FallLady.Mood.Framework.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Domain.Domain.Courses
{
    public interface ICourseRepository : IReadRepository<Course, int>, IWriteRepository<Course, int>, IQueryRepository<Course, int>,IDeleteRepository<Course, int>
    {
        public Task<bool> CheckIfCourseIsUsedInOrders(Course course);
        public void DeleteCourseTags(Course entity);
    }
}
