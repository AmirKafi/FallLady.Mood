using FallLady.Mood.Application.Contract.Dto.Category;
using FallLady.Mood.Application.Contract.Dto.Teacher;
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
    }
}
