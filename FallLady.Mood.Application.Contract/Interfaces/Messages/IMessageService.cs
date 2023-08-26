using FallLady.Mood.Application.Contract.Dto.Messages;
using FallLady.Mood.Utility.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Contract.Interfaces.Messages
{
    public interface IMessageService
    {
        Task<ServiceResponse<List<MessageListDto>>> LoadMessages(MessageDto dto);
        Task<ServiceResponse<bool>> AddMessage(MessageCreateDto dto);
        Task<ServiceResponse<MessageUpdateDto>> GetMessage(int messageId);
        Task<ServiceResponse<bool>> Read(int messageId,string readerId);
    }
}
