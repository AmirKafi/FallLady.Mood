using FallLady.Mood.Domain.Domain.Course;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Persistance
{
    public class FallLadyDbContext : DbContext
    {

        protected FallLadyDbContext()
        {

        }

        public FallLadyDbContext(DbContextOptions<FallLadyDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Initial Catalog=FallLady.Mood;Persist Security Info=True;MultipleActiveResultSets=true;User ID=sa;Password=ASD110asd;TrustServerCertificate=Yes");
            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

        public DbSet<Course> Courses { get; set; }
    }
}
