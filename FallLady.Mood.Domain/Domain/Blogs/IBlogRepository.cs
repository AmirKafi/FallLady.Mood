using FallLady.Mood.Domain.Domain.Blogs;
using FallLady.Mood.Framework.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Domain.Domain.Blogs
{
    public interface IBlogRepository : IReadRepository<Blog, int>, IWriteRepository<Blog, int>, IQueryRepository<Blog, int>, IDeleteRepository<Blog, int>
    {
    }
}
