using FallLady.Mood.Application.Contract.Dto.Course;
using FallLady.Mood.Application.Contract.Interfaces;
using FallLady.Mood.Application.Contract.Mappers;
using FallLady.Mood.Domain.Domain.Course;
using FallLady.Mood.Utility.ServiceResponse;
using FallLady.Persistance.Repositories.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Services.Course
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

        public async Task<ServiceResponse<bool>> AddCourse(CourseCreateDto dto)
        {
            var result = new ServiceResponse<bool>();
            try
            {
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
                course.Update(dto.Title, dto.CourseType, dto.Price, dto.Description, dto.LicenseKey,dto.FileName);

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
