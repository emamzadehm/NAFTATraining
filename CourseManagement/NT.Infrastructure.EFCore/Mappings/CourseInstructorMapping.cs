using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using NT.CM.Domain.CourseInstructorAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.CM.Infrastructure.EFCore.Mappings
{
    public class CourseInstructorMapping : IEntityTypeConfiguration<CourseInstructor>
    {
        public void Configure(EntityTypeBuilder<CourseInstructor> builder)
        {
            builder.ToTable("Tbl_Course_Instructor");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.CourseID);
            builder.Property(x => x.InstructorID);
            builder.Property(x => x.SDate);
            builder.Property(x => x.EDate);
            builder.Property(x => x.Capacity);
            builder.Property(x => x.Venue);
            builder.Property(x => x.Location);
            builder.Property(x => x.IsPrivate);
            builder.Property(x => x.Status);
            builder.HasOne(x => x.Instructor).WithMany(x => x.CourseInstructors).HasForeignKey(x => x.InstructorID);
            builder.HasOne(x => x.Course).WithMany(x => x.CourseInstructors).HasForeignKey(x => x.CourseID);
            builder.HasOne(x => x.BaseInfo).WithMany(x => x.CourseInstructors).HasForeignKey(x => x.Location);
            builder.HasMany(x => x.CandidateCourseInstructors).WithOne(x => x.CourseInstructors).HasForeignKey(x => x.Course_InstructorID);
        }
    }
}
