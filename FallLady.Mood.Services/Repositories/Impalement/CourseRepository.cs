using FallLady.Mood.Data.Context;
using FallLady.Mood.Data.Domain;
using FallLady.Mood.Models.DTO;
using FallLady.Mood.Models.ViewModels;
using FallLady.Mood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FallLady.Mood.Services.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace FallLady.Mood.Services.Repositories.Impalement
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SqlContext _db;

        public CourseRepository(SqlContext db)
        {
            _db = db;
        }

        public Task<bool> Delete(List<int> courseIds)
        {
            throw new NotImplementedException();
        }

        public Task<CourseViewModel> Get(CourseViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<KeyValuePair<int, List<CourseViewModel>>> Load(CourseDto courseDto)
        {
            int totalCount = await _db.Courses.CountAsync().ConfigureAwait(false);
            int skip = (courseDto.pageNumber /*- 1*/) * courseDto.pageSize;

            var listCourses = await _db.Courses
                .AsNoTracking()
                .ProjectTo<CourseViewModel>(AutoMapperConfig.Mapper.ConfigurationProvider)
                .Skip(skip)
                .Take(courseDto.pageSize)
                .ToListAsync()
                .ConfigureAwait(false);

            return new KeyValuePair<int, List<CourseViewModel>>(totalCount, listCourses);
        }

        public async Task<int> Save(CourseViewModel model)
        {
            var mapper = AutoMapperConfig.Mapper.Map<Course>(model);


            mapper.CreateDate = DateTime.Now;

            await _db.Courses.AddAsync(mapper);
            await _db.SaveChangesAsync();

            return mapper.Id;
        }
    }
}
