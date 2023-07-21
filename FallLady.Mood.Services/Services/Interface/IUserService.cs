using FallLady.Mood.Data.Domain;
using FallLady.Mood.Infrastructure.Utility.Service;
using FallLady.Mood.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Services.Services.Interface
{
    public interface IUserService
    {
        Task<ServiceResponse<List<User>>> Load(UserDto userDto);
    }
}
