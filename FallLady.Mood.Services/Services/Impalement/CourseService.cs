using FallLady.Mood.Infrastructure.Utility.Service;
using FallLady.Mood.Models.DTO;
using FallLady.Mood.Models.ViewModels;
using FallLady.Mood.Services.Repositories.Interface;
using FallLady.Mood.Services.Services.Interface;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Services.Services.Impalement
{
    public class CourseService : ICourseService
    {
        #region Constructor
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        #endregion
        public async Task<ServiceResponse<List<CourseViewModel>>> Load(CourseDto courseDto)
        {
            var result = new ServiceResponse<List<CourseViewModel>>();
            try
            {
                var data = await _courseRepository.Load(courseDto).ConfigureAwait(false);
                result.SetData(data.Value, data.Key);
            }
            catch (Exception exception)
            {
                result.SetException(exception);
            }

            return result;
        }

        public async Task<ServiceResponse<int>> Save(CourseViewModel model)
        {
            var result = new ServiceResponse<int>();
            try
            {
                var data = await _courseRepository.Save(model).ConfigureAwait(false);
                result.SetData(data);
            }
            catch (Exception exception)
            {
                result.SetException(exception);
            }

            return result;
        }

        public async Task<ServiceResponse<CourseViewModel>> Get(int id)
        {
            var result = new ServiceResponse<CourseViewModel>();
            try
            {
                var data = await _courseRepository.Get(id).ConfigureAwait(false);
                result.SetData(data);
            }
            catch (Exception exception)
            {
                result.SetException(exception);
            }
            return result;
        }

        public async Task<ServiceResponse<bool>> Delete(List<int> courseIds)
        {
            var result = new ServiceResponse<bool>();
            try
            {
                var data = await _courseRepository.Delete(courseIds).ConfigureAwait(false);
                result.SetData(data);
            }
            catch (Exception exception)
            {
                result.SetException(exception);
            }

            return result;
        }
    }
}
