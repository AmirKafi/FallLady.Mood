using FallLady.Mood.Data.Domain;
using FallLady.Mood.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Services.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<KeyValuePair<int, List<User>>> Load(UserDto userDto);
    }
}
