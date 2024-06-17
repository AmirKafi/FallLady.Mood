using FallLady.Mood.Domain.Domain.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Persistance.Configurations
{
    public class CourseTagsEFConfig : IEntityTypeConfiguration<CourseTags>
    {
        public void Configure(EntityTypeBuilder<CourseTags> builder)
        {
            builder.HasNoKey();
        }
    }
}
