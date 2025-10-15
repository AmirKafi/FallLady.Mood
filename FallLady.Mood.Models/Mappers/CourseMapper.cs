using AutoMapper;
using FallLady.Mood.Core.Utilities;
using FallLady.Mood.Data.Domain;
using FallLady.Mood.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Models.Mappers
{
    public class CourseMapper : Profile
    {
        public CourseMapper()
        {
            CreateMap<Course, CourseViewModel>()
                .ForMember(member => member.OriginalImageFile, option => option.Ignore())
                .ForMember(member => member.CourseTypeTitle, option => option.Ignore())
                .ReverseMap()
                ;
        }
    }
}
