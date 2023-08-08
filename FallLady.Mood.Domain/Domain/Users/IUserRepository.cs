using FallLady.Mood.Domain.Domain.Teachers;
using FallLady.Mood.Framework.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Domain.Domain.Users
{
    public interface IUserRepository : IReadRepository<User, int>, IWriteRepository<User, int>, IQueryRepository<User, int>, IDeleteRepository<User, int>
    {
        public Task<User> Login(string username, string password);
    }
}
