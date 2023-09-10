using FallLady.Mood.Domain.Domain.Blogs;
using FallLady.Mood.Domain.Domain.Categories;
using FallLady.Mood.Domain.Domain.Configs;
using FallLady.Mood.Domain.Domain.Courses;
using FallLady.Mood.Domain.Domain.Discounts;
using FallLady.Mood.Domain.Domain.Favourites;
using FallLady.Mood.Domain.Domain.Tags;
using FallLady.Mood.Domain.Domain.Teachers;
using FallLady.Mood.Domain.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=FallLady.Mood;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=true;");
            //optionsBuilder.UseSqlServer("Server=.;Initial Catalog=FallLady.Mood;Persist Security Info=True;MultipleActiveResultSets=true;User ID=sa;Password=ASD110asd;TrustServerCertificate=Yes");
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Config> Configs { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Discount> Discounts { get; set; }
    }
}
