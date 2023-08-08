using FallLady.Mood.Application.Contract.Dto.Teacher;
using FallLady.Mood.Application.Contract.Interfaces.Teachers;
using FallLady.Mood.Application.Contract.Mappers.Teachers;
using FallLady.Mood.Domain.Domain.Teachers;
using FallLady.Mood.Framework.Core;
using FallLady.Mood.Framework.Core.Enum;
using FallLady.Mood.Utility.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Services.Teacher
{
    public class TeacherSerivce : ITeacherService
    {
        #region Constructor
        private readonly ITeacherRepository _repository;
        public TeacherSerivce(ITeacherRepository repository)
        {
            _repository = repository;
        }

        #endregion

        public async Task<ServiceResponse<List<TeacherListDto>>> LoadTeachers(TeacherDto dto)
        {
            var result = new ServiceResponse<List<TeacherListDto>>();
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

        public async Task<ServiceResponse<bool>> AddTeacher(TeacherCreateDto dto)
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

        public async Task<ServiceResponse<TeacherUpdateDto>> GetTeacher(int teacherId)
        {
            var result = new ServiceResponse<TeacherUpdateDto>();
            try
            {
                var data = await _repository.Get(teacherId);
                result.SetData(data.ToDto());
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> UpdateTeacher(TeacherUpdateDto dto)
        {
            var result = new ServiceResponse<bool>();
            try
            {
                var teacher = await _repository.Get(dto.Id);
                teacher.Update(dto.FullName);

                await _repository.Update(teacher);

                result.SetData(true);
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> Delete(int teacherId)
        {
            var result = new ServiceResponse<bool>();
            try
            {
                var teacher = await _repository.GetById(teacherId);
                await _repository.Delete(teacher);

                result.SetData(true);
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<List<ComboModel>>> GetAsCombo()
        {
            var result = new ServiceResponse<List<ComboModel>>();
            try
            {
                var teacher = _repository.GetQuerable();
                var teachers = teacher.Select(x=> x.ToComboModel()).ToList();

                result.SetData(teachers);
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }
    }
}
