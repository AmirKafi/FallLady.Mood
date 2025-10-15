using FallLady.Mood.Data.Domain;
using FallLady.Mood.Infrastructure.Utility.Service;
using FallLady.Mood.Models.DTO;
using FallLady.Mood.Models.ViewModels;
using FallLady.Mood.Services.Repositories.Interface;
using FallLady.Mood.Services.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Services.Services.Impalement
{
    public class UserService : IUserService
    {
        #region Constructor
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion
        public async Task<ServiceResponse<List<User>>> Load(UserDto userDto)
        {
            var result = new ServiceResponse<List<User>>();
            try
            {
                var data = await _userRepository.Load(userDto).ConfigureAwait(false);
                result.SetData(data.Value, data.Key);
            }
            catch (Exception exception)
            {
                result.SetException(exception);
            }

            return result;
        }
    }
}
