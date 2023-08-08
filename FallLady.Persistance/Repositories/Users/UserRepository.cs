using FallLady.Mood.Domain.Domain.Teachers;
using FallLady.Mood.Domain.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Persistance.Repositories.Users
{
    public class UserRepository : CrudRepository<User, int>, IUserRepository
    {
        public Task<User> Login(string username, string password)
        {
            var user = _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == username && x.Password == password);
            return user;
        }
    }
}
