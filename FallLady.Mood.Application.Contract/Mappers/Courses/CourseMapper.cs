﻿using FallLady.Mood.Application.Contract.Dto.Course;
using FallLady.Mood.Domain.Domain.Courses;
using FallLady.Mood.Framework.Core;
using FallLady.Mood.Framework.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Contract.Mappers.Courses
{
    public static class CourseMapper
    {
        public static Course ToModel(this CourseCreateDto dto)
        {
            return new Course(dto.Title,
                              dto.CourseType.Value,
                              dto.Price.Value,
                              dto.Description,
                              dto.LicenseKey,
                              dto.FileName,
                              dto.FromTime,
                              dto.ToTime,
                              dto.FromDate,
                              dto.ToDate,
                              dto.EventAddress,
                              dto.EventDays,
                              dto.TeacherId);
        }

        public static List<CourseListDto> ToDto(this IEnumerable<Course>? model)
        {
            if (model is null)
                return new List<CourseListDto>();

            return model.Select(x => new CourseListDto()
            {
                Id = x.Id,
                Title = x.Title,
                CourseType = x.CourseType,
                Price = x.Price,
                Description = x.Description,
                FileName = x.FileName,
                EventAddress = x.EventAddress,
                FromTime = TimeOnly.FromDateTime(x.FromDate ?? default),
                ToTime = TimeOnly.FromDateTime(x.ToDate ?? default),
                FromDate = DateOnly.FromDateTime(x.FromDate ?? default),
                ToDate = DateOnly.FromDateTime(x.ToDate ?? default),
                TeacherName = x.Teacher is null ? "" : x.Teacher.FullName
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
                LicenseKey = model.LicenseKey,
                FileName = model.FileName,
                EventAddress = model.EventAddress,
                FromTime = TimeOnly.FromDateTime(model.FromDate ?? default),
                ToTime = TimeOnly.FromDateTime(model.ToDate ?? default),
                FromDate = DateOnly.FromDateTime(model.FromDate ?? default),
                ToDate = DateOnly.FromDateTime(model.ToDate ?? default),
                EventDays = model.EventDays.Select(x => (WeekDaysEnum)x.WeekDayId).ToList(),
                TeacherId = model.TeacherId,
            };
        }

        
    }
}
