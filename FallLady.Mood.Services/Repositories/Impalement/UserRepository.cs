using FallLady.Mood.Data.Domain;
using FallLady.Mood.Models.DTO;
using FallLady.Mood.Services.Repositories.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Services.Repositories.Impalement
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;

        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<KeyValuePair<int, List<User>>> Load(UserDto userDto)
        {
            int totalCount = await _userManager.Users.CountAsync().ConfigureAwait(false);
            int skip = (userDto.pageNumber /*- 1*/) * userDto.pageSize;

            var listCourses = await _userManager.Users
                .AsNoTracking()
                .Skip(skip)
                .Take(userDto.pageSize)
                .ToListAsync()
                .ConfigureAwait(false);

            return new KeyValuePair<int, List<User>>(totalCount, listCourses);
        }
    }
}
