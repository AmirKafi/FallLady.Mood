using FallLady.Mood.Application.Contract.Dto.Users;
using FallLady.Mood.Application.Contract.Interfaces.Users;
using FallLady.Mood.Application.Contract.Mappers.Users;
using FallLady.Mood.Domain.Domain.Users;
using FallLady.Mood.Framework.Core;
using FallLady.Mood.Framework.Core.Enum;
using FallLady.Mood.Utility.Extentions;
using FallLady.Mood.Utility.ServiceResponse;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FallLady.Mood.Application.Services.Users
{
    public class UserService:IUserService
    {
        #region Constructor
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ApplicationSettingsModel _settings;

        public UserService(IConfigurationRoot configuration,
                           SignInManager<User> signInManager,
                           UserManager<User> userManager)
        {
            _settings = configuration.GetSection("ApplicationSettings").Get<ApplicationSettingsModel>();
            _signInManager = signInManager;
            _userManager = userManager;
        }

        #endregion

        public async Task<ServiceResponse<SignInResult>> Login(string username, string password)
        {
            var result = new ServiceResponse<SignInResult>();
            try
            {
                var user = await _signInManager.PasswordSignInAsync(username, password,true,true);
                if (!user.Succeeded)
                    throw new Exception("نام کاربری یا کلمه عبور اشتباه است");

                result.SetData(user);
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<List<UserListDto>>> LoadUsers(UserDto dto)
        {
            var result = new ServiceResponse<List<UserListDto>>();
            try
            {
                var data = await _userManager.Users.Skip(dto.offset * dto.limit).Take(dto.offset).ToListAsync();
                result.SetData(data.ToDto());
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<IdentityResult>> AddUser(UserCreateDto dto)
        {
            var result = new ServiceResponse<IdentityResult>();
            try
            {
                GuardAgainstPasswordConflict(dto.Password, dto.ConfirmPassword);
                var user = await _userManager.CreateAsync(dto.ToModel());
                result.SetData(user);
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<UserUpdateDto>> GetUser(int UserId)
        {
            var result = new ServiceResponse<UserUpdateDto>();
            try
            {
                var data = await _userManager.Users.FirstOrDefaultAsync(x=> x.Id == UserId);
                if (data is null)
                    throw new Exception("کاربر مورد نظر یافت نشد");

                result.SetData(data.ToDto());
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> UpdateUser(UserUpdateDto dto)
        {
            var result = new ServiceResponse<bool>();
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == dto.Id);
                if (user is null)
                    throw new Exception("کاربر مورد نظر یافت نشد");

                user.Update(dto.UserName,
                            dto.FirstName,
                            dto.LastName,
                            dto.PhoneNumber,
                            dto.Role,
                            dto.Email,
                            dto.IsActive);

                var res = await _userManager.UpdateAsync(user);
                result.SetData(true);
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> Delete(int userId)
        {
            var result = new ServiceResponse<bool>();
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);

                if (user is null)
                    throw new Exception("کاربر مورد نظر یافت نشد");

                await _userManager.DeleteAsync(user);

                result.SetData(true);
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        #region Private

        private void GuardAgainstPasswordConflict(string password,string confirmPassword)
        {
            if (!password.Equals(confirmPassword))
                throw new Exception("پسورد ها باهم یکسان نیستند");
        }
        #endregion

    }
}
