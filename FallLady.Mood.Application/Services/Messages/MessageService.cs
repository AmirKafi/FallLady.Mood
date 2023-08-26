using FallLady.Mood.Application.Contract.Dto.Messages;
using FallLady.Mood.Application.Contract.Interfaces.Messages;
using FallLady.Mood.Application.Contract.Mappers.Messages;
using FallLady.Mood.Domain.Domain.Categories;
using FallLady.Mood.Domain.Domain.Courses;
using FallLady.Mood.Domain.Domain.Messages;
using FallLady.Mood.Utility.ServiceResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Services.Messages
{
    public class MessageService : IMessageService
    {
        #region Constructor
        private readonly IMessageRepository _repository;
        public MessageService(IMessageRepository repository)
        {
            _repository = repository;
        }

        #endregion

        public async Task<ServiceResponse<List<MessageListDto>>> LoadMessages(MessageDto dto)
        {
            var result = new ServiceResponse<List<MessageListDto>>();
            try
            {
                var data = _repository.GetQuerable()
                                      .Include(x=> x.Sender)
                                      .Include(x=> x.Reader)
                                      .Skip(dto.offset * dto.limit)
                                      .Take(dto.limit);
                result.SetData(data.ToDto());
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> AddMessage(MessageCreateDto dto)
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

        public async Task<ServiceResponse<MessageUpdateDto>> GetMessage(int messageId)
        {
            var result = new ServiceResponse<MessageUpdateDto>();
            try
            {
                var data = await _repository.Get(messageId);
                result.SetData(data.ToDto());
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> Read(int messageId,string readerId)
        {
            var result = new ServiceResponse<bool>();
            try
            {
                var message = await _repository.Get(messageId);
                message.Read(readerId);
                await _repository.Update(message);
                result.SetData(true);
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }
    }
}
