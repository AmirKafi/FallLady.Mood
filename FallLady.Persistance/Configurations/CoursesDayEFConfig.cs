using FallLady.Mood.Domain.Domain.Course;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Persistance.Configurations
{
    public class CourseDaysEFConfig : IEntityTypeConfiguration<CourseDays>
    {
        public void Configure(EntityTypeBuilder<CourseDays> builder)
        {
            builder.HasOne(s => s.Course)
                .WithMany(d => d.EventDays)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
