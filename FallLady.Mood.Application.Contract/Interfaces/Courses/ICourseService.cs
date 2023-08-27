using FallLady.Mood.Application.Contract.Dto.Course;
using FallLady.Mood.Utility.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Contract.Interfaces.Course
{
    public interface ICourseService
    {
        Task<ServiceResponse<List<CourseListDto>>> LoadCourses(CourseDto dto);
        Task<ServiceResponse<List<CourseListDto>>> LoadCourses();
        Task<ServiceResponse<bool>> AddCourse(CourseCreateDto dto);
        Task<ServiceResponse<CourseUpdateDto>> GetCourse(int courseId);
        Task<ServiceResponse<CourseDetailsDto>> GetCourseDetails(int courseId);
        Task<ServiceResponse<bool>> UpdateCourse(CourseUpdateDto dto);
        Task<ServiceResponse<bool>> Delete(int courseId);
    }
}
