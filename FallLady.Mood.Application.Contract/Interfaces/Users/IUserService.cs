using FallLady.Mood.Application.Contract.Dto.Users;
using FallLady.Mood.Framework.Core;
using FallLady.Mood.Utility.ServiceResponse;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FallLady.Mood.Application.Contract.Interfaces.Users
{
    public interface IUserService
    {
        Task<ServiceResponse<List<UserListDto>>> LoadUsers(UserDto dto);
        Task<ServiceResponse<List<ComboModel>>> LoadUsers();
        Task<ServiceResponse<SignInResult>> Login(string username, string password);
        Task SignOut(ClaimsPrincipal principal);
        Task<ServiceResponse<IdentityResult>> AddUser(UserCreateDto dto);
        Task<ServiceResponse<UserUpdateDto>> GetUser(string userId);
        Task<ServiceResponse<UserUpdateDto>> GetUser(ClaimsPrincipal principal);
        Task<ServiceResponse<string>> GetUserId(ClaimsPrincipal principal);
        Task<ServiceResponse<bool>> UpdateUser(UserUpdateDto dto);
        Task<ServiceResponse<bool>> ChangePassword(ChangePasswordDto dto);
        Task<ServiceResponse<bool>> Delete(string userId);
    }
}
