using FallLady.Mood.Application.Contract.Dto.Users;
using FallLady.Mood.Domain.Domain.Users;
using FallLady.Mood.Framework.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Contract.Mappers.Users
{
    public static class UserMapper
    {
        public static User ToModel(this UserCreateDto dto)
        {
            return new User(dto.UserName,
                            dto.FirstName,
                            dto.LastName,
                            dto.PhoneNumber,
                            dto.Role,
                            dto.Email,
                            dto.Password,
                            dto.PasswordExiresOn);
        }

        public static List<UserListDto> ToDto(this IEnumerable<User>? model)
        {
            if (model is null)
                return new List<UserListDto>();

            return model.Select(x => new UserListDto()
            {
                Id = x.Id,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                LastName = x.LastName,
                FirstName = x.FirstName,
                UserName = x.UserName,
                Role = x.Role
            }).ToList();
        }

        public static UserUpdateDto ToDto(this User model)
        {
            return new UserUpdateDto()
            {
                Id = model.Id,
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email
            };
        }

        public static UserTokenDto ToTokenDto(this User user,string token)
        {
            return new UserTokenDto()
            {
                Id = user.Id,
                Username = user.UserName,
                AccessToken = "Barear " + token
            };
        }
    }
}
