using FallLady.Mood.Application.Contract.Dto.Course;
using FallLady.Mood.Domain.Domain.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Contract.Mappers
{
    public static class CourseMapper
    {
        public static Course ToModel(this CourseCreateDto dto)
        {
            return new Course(dto.Title,dto.CourseType.Value,dto.Price.Value, dto.Description,dto.LicenseKey);
        }

        public static List<CourseListDto> ToDto(this IEnumerable<Course>? model)
        {
            if(model is null)
                return new List<CourseListDto>();

            return model.Select(x=> new CourseListDto()
            {
                Title = x.Title,
                CourseType = x.CourseType,
                Price = x.Price,
                Description = x.Description
            }).ToList();
        }

        public static CourseUpdateDto ToDto(this Course model)
        {
            return new CourseUpdateDto()
            {
                Id = model.Id,
                Title = model.Title,
                CourseType = model.CourseType,
                Price = model.Price,
                Description = model.Description,
                LicenseKey = model.LicenseKey
            };
        }
    }
}
