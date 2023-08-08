using FallLady.Mood.Application.Contract.Dto.Users;
using FallLady.Mood.Utility.ServiceResponse;

namespace FallLady.Mood.Application.Contract.Interfaces.Users
{
    public interface IUserService
    {
        Task<ServiceResponse<List<UserListDto>>> LoadUsers(UserDto dto);
        Task<ServiceResponse<UserTokenDto>> Login(string username, string password);
        Task<ServiceResponse<bool>> AddUser(UserCreateDto dto);
        Task<ServiceResponse<UserUpdateDto>> GetUser(int userId);
        Task<ServiceResponse<bool>> UpdateUser(UserUpdateDto dto);
        Task<ServiceResponse<bool>> Delete(int userId);
    }
}
