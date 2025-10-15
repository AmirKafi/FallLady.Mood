using FallLady.Mood.Data.Domain;
using FallLady.Mood.Infrastructure.Utility.Service;
using FallLady.Mood.Models.DTO;
using FallLady.Mood.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Services.Services.Interface
{
    public interface ICourseService
    {
        Task<ServiceResponse<List<CourseViewModel>>> Load(CourseDto courseDto);

        Task<ServiceResponse<int>> Save(CourseViewModel model);

        Task<ServiceResponse<CourseViewModel>> Get(int id);

        Task<ServiceResponse<bool>> Delete(List<int> courseIds);
    }
}
