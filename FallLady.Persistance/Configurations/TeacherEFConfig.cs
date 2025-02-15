﻿using FallLady.Mood.Domain.Domain.Courses;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FallLady.Mood.Domain.Domain.Teachers;

namespace FallLady.Persistance.Configurations
{
    public class TeacherEFConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasMany(s => s.Courses)
                .WithOne(d => d.Teacher)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
