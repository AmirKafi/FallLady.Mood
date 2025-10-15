using FallLady.Mood.Data.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Data.Context
{
    public class SqlContext:DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options): base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }
    }
}
