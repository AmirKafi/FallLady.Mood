using FallLady.Mood.Application.Contract.Dto.Users;
using FallLady.Mood.Application.Contract.Interfaces.Users;
using FallLady.Mood.Application.Contract.Mappers.Users;
using FallLady.Mood.Domain.Domain.Users;
using FallLady.Mood.Framework.Core;
using FallLady.Mood.Framework.Core.Enum;
using FallLady.Mood.Utility.ServiceResponse;
using Microsoft.AspNetCore.Hosting;
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

namespace FallLady.Mood.Application.Services.Users
{
    public class UserService:IUserService
    {
        #region Constructor
        private readonly IUserRepository _repository;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ApplicationSettingsModel _settings;

        public UserService(IUserRepository repository,
                           IConfigurationRoot configuration)
        {
            _settings = configuration.GetSection("ApplicationSettings").Get<ApplicationSettingsModel>();
            _repository = repository;
        }

        #endregion

        public async Task<ServiceResponse<UserTokenDto>> Login(string username, string password)
        {
            var result = new ServiceResponse<UserTokenDto>();
            try
            {
                var user = await _repository.Login(username,password);
                result.SetData(await GetToken(user));
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
                var data = await _repository.GetList(dto.offset, dto.limit);
                result.SetData(data.ToDto());
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> AddUser(UserCreateDto dto)
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

        public async Task<ServiceResponse<UserUpdateDto>> GetUser(int UserId)
        {
            var result = new ServiceResponse<UserUpdateDto>();
            try
            {
                var data = await _repository.Get(UserId);
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
                var user = await _repository.Get(dto.Id);
                user.Update(dto.UserName,
                            dto.FirstName,
                            dto.LastName,
                            dto.PhoneNumber,
                            dto.Role,
                            dto.Email);

                await _repository.Update(user);

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
                var user = await _repository.GetById(userId);
                await _repository.Delete(user);

                result.SetData(true);
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        #region Private

        private Task<UserTokenDto> GetToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Jwt_SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sid, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, user.UserName),
                new Claim("Role", user.Role.ToString()),
             };

            var token = new JwtSecurityToken(
            issuer: _settings.Jwt_Issuer,
                audience: _settings.Jwt_Audience,
                claims: claims,
                expires: DateTime.Now.AddHours(_settings.ExpiresOn),
                signingCredentials: credentials);

            return Task.FromResult(user.ToTokenDto(new JwtSecurityTokenHandler().WriteToken(token)));
        }

        #endregion

    }
}
