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
            builder.Property(x => x.CName);
            builder.Property(x => x.Description);
            builder.Property(x => x.Audience);
            builder.Property(x => x.DailyPlan);
            builder.Property(x => x.Cost);
            builder.Property(x => x.CourseCatalog);
            builder.Property(x => x.CourseLevel);
            builder.Property(x => x.Duration);
            builder.Property(x => x.CategoryID);
            builder.Property(x => x.Status);
            builder.Property(x => x.IsPrivate);
            builder.HasOne(x => x.BaseInfoCourseLevel).WithMany(x => x.CourseLevels).HasForeignKey(x => x.CourseLevel);
            builder.HasOne(x => x.BaseInfoCategory).WithMany(x => x.CourseCategoriers).HasForeignKey(x => x.CategoryID);
            builder.HasMany(x => x.CourseInstructors).WithOne(x=>x.Course).HasForeignKey(x=>x.CourseID);
        }
    }
}
