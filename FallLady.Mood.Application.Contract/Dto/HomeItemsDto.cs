using FallLady.Mood.Application.Contract.Dto.Category;
using FallLady.Mood.Application.Contract.Dto.Course;
using FallLady.Mood.Application.Contract.Dto.Teacher;
using FallLady.Mood.Application.Contract.Dto.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Contract.Dto
{
    public class HomeItemsDto
    {
        public List<CategoryListDto> Categories { get; set; }
        public List<TeacherListDto> Teachers { get; set; }
        public List<CourseListDto> Courses { get; set; }
        public UserUpdateDto CurrentUser { get; set; }
    }
}
