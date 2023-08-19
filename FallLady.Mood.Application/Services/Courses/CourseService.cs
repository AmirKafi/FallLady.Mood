using FallLady.Mood.Application.Contract.Dto.Course;
using FallLady.Mood.Application.Contract.Interfaces.Course;
using FallLady.Mood.Application.Contract.Mappers.Courses;
using FallLady.Mood.Domain.Domain.Courses;
using FallLady.Mood.Framework.Core.Enum;
using FallLady.Mood.Utility.ServiceResponse;
using FallLady.Persistance.Repositories.Course;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Services.Courses
{
    public class CourseService:ICourseService
    {
        #region Constructor

        private readonly ICourseRepository _repository;

        public CourseService(ICourseRepository repository)
        {
            _repository = repository;
        }

        #endregion

        public async Task<ServiceResponse<List<CourseListDto>>> LoadCourses(CourseDto dto)
        {
            var result = new ServiceResponse<List<CourseListDto>>();
            try
            {
                var data = await _repository.GetList(dto.offset, dto.limit);
                result.SetData(data.ToDto());
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<List<CourseListDto>>> LoadCourses()
        {
            var result = new ServiceResponse<List<CourseListDto>>();
            try
            {
                var data =  _repository.GetQuerable()
                                   .Include(x => x.Teacher)
                                   .Include(x => x.EventDays)
                                   .Include(x => x.Category)
                                   .AsNoTracking();
                result.SetData(data.ToDto());
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> AddCourse(CourseCreateDto dto)
        {
            var result = new ServiceResponse<bool>();
            try
            {
                if (dto.EventDays is null) dto.EventDays = new List<WeekDaysEnum>();
                await _repository.Add(dto.ToModel());
                result.SetData(true);
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<CourseUpdateDto>> GetCourse(int courseId)
        {
            var result = new ServiceResponse<CourseUpdateDto>();
            try
            {
                var data =  await _repository.Get(courseId);
                result.SetData(data.ToDto());
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> UpdateCourse(CourseUpdateDto dto)
        {
            var result = new ServiceResponse<bool>();
            try
            {
                var course = await _repository.Get(dto.Id);
                if (dto.EventDays is null) dto.EventDays = new List<WeekDaysEnum>();
                course.Update(dto.Title, 
                              dto.CourseType,
                              dto.Price,
                              dto.Description,
                              dto.LicenseKey,
                              dto.FileName,
                              dto.FromTime,
                              dto.ToTime,
                              dto.FromDate,
                              dto.ToDate,
                              dto.EventAddress,
                              dto.EventDays,
                              dto.TeacherId,
                              dto.CategoryId);

                await _repository.Update(course);

                result.SetData(true);
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> Delete(int courseId)
        {
            var result = new ServiceResponse<bool>();
            try
            {
                var course = await _repository.GetById(courseId);
                await _repository.Delete(course);

                result.SetData(true);
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }
    }
}
