using FallLady.Mood.Application.Contract.Dto.Users;
using FallLady.Mood.Utility.ServiceResponse;
using Microsoft.AspNetCore.Identity;

namespace FallLady.Mood.Application.Contract.Interfaces.Users
{
    public interface IUserService
    {
        Task<ServiceResponse<List<UserListDto>>> LoadUsers(UserDto dto);
        Task<ServiceResponse<SignInResult>> Login(string username, string password);
        Task<ServiceResponse<IdentityResult>> AddUser(UserCreateDto dto);
        Task<ServiceResponse<UserUpdateDto>> GetUser(int userId);
        Task<ServiceResponse<bool>> UpdateUser(UserUpdateDto dto);
        Task<ServiceResponse<bool>> Delete(int userId);
    }
}
