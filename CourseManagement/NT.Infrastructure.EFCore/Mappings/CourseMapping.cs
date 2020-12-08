using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NT.CM.Domain.CourseAgg;


namespace NT.CM.Infrastructure.EFCore.Mappings
{
    public class CourseMapping : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Tbl_Course");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.CName).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Audience).IsRequired();
            builder.Property(x => x.DailyPlan).IsRequired();
            builder.Property(x => x.Cost).IsRequired();
            builder.Property(x => x.CourseCatalog).HasMaxLength(2000).IsRequired(false);
            builder.Property(x => x.CourseLevel).IsRequired();
            builder.Property(x => x.Duration).IsRequired();
            builder.Property(x => x.CategoryID).IsRequired();
            builder.Property(x => x.Status);
            builder.HasOne(x => x.BaseInfoCourseLevel).WithMany(x => x.CourseLevels).HasForeignKey(x => x.CourseLevel);
            builder.HasOne(x => x.BaseInfoCategory).WithMany(x => x.CourseCategoriers).HasForeignKey(x => x.CategoryID);
            builder.HasMany(x => x.CourseInstructors).WithOne(x=>x.Course).HasForeignKey(x=>x.CourseID);
        }
    }
}
