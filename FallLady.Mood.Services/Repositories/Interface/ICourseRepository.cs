using FallLady.Mood.Infrastructure.Utility.Service;
using FallLady.Mood.Models.DTO;
using FallLady.Mood.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Services.Repositories.Interface
{
    public interface ICourseRepository
    {
        Task<KeyValuePair<int, List<CourseViewModel>>> Load(CourseDto courseDto);
        Task<int> Save(CourseViewModel model);
        Task<CourseViewModel> Get(CourseViewModel model);
        Task<bool> Delete(List<int> courseIds);
    }
}
