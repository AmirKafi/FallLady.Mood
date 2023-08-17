using FallLady.Mood.Domain.Domain.Categories;
using FallLady.Mood.Domain.Domain.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Persistance.Repositories.Categories
{
    public class CategoryRepository : CrudRepository<Category, int>, ICategoryRepository
    {
    }
}
