using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NT.CM.Domain.CourseInstructorAgg;

namespace NT.CM.Infrastructure.EFCore.Mappings
{
    public class CourseInstructorMapping : IEntityTypeConfiguration<CourseInstructor>
    {
        public void Configure(EntityTypeBuilder<CourseInstructor> builder)
        {
            builder.ToTable("Tbl_Course_Instructor");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.CourseID).IsRequired();
            builder.Property(x => x.InstructorID).IsRequired();
            builder.Property(x => x.SDate).HasMaxLength(10).IsRequired();
            builder.Property(x => x.EDate).HasMaxLength(10).IsRequired();
            builder.Property(x => x.Capacity).HasMaxLength(2).IsRequired();
            builder.Property(x => x.Venue).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Location).IsRequired();
            builder.Property(x => x.IsPrivate);
            builder.Property(x => x.Status);
            builder.HasOne(x => x.Instructor).WithMany(x => x.CourseInstructors).HasForeignKey(x => x.InstructorID);
            builder.HasOne(x => x.Course).WithMany(x => x.CourseInstructors).HasForeignKey(x => x.CourseID);
            builder.HasOne(x => x.BaseInfo).WithMany(x => x.CourseInstructors).HasForeignKey(x => x.Location);
            builder.HasMany(x => x.CandidateCourseInstructors).WithOne(x => x.CourseInstructors).HasForeignKey(x => x.Course_InstructorID);
        }
    }
}
