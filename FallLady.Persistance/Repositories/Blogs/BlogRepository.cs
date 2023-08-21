using FallLady.Mood.Domain.Domain.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Persistance.Repositories.Blogs
{
    public class BlogRepository:CrudRepository<Blog,int>,IBlogRepository
    {
    }
}
