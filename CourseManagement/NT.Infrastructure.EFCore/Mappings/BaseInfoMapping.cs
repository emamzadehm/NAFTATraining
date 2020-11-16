using Domain.BaseInfoAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NT.CM.Infrastructure.EFCore.Mappings
{
    public class BaseInfoMapping : IEntityTypeConfiguration<BaseInfo>
    {
        public void Configure(EntityTypeBuilder<BaseInfo> builder)
        {
            builder.ToTable("Tbl_Base_Info");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Title).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.TypeID);
            builder.Property(x => x.ParentID);
            builder.Property(x => x.Status);
            //* Relationships
            //BaseInfo Self cascade implimentation
            builder.HasOne(x => x.Type).WithMany(x => x.TypeChilds).HasForeignKey(x => x.TypeID);
            builder.HasOne(x => x.Parent).WithMany(x => x.ParentChilds).HasForeignKey(x => x.ParentID);
            builder.HasMany(x => x.TypeChilds).WithOne(x => x.Type).HasForeignKey(x => x.TypeID);
            builder.HasMany(x => x.ParentChilds).WithOne(x => x.Parent).HasForeignKey(x => x.ParentID);
            //BaseInfo-Course implimentation
            builder.HasMany(x => x.CourseLevels).WithOne(x => x.BaseInfoCourseLevel).HasForeignKey(x => x.CourseLevel);
            builder.HasMany(x => x.CourseCategoriers).WithOne(x => x.BaseInfoCategory).HasForeignKey(x => x.CategoryID);

            builder.HasMany(x => x.CourseCandidateInstructorDetails).WithOne(x => x.BaseInfo).HasForeignKey(x => x.TypeID);

            builder.HasMany(x => x.CourseInstructors).WithOne(x => x.BaseInfo).HasForeignKey(x => x.Location);

            builder.HasMany(x => x.Galleries).WithOne(x => x.BaseInfo).HasForeignKey(x => x.TypeID);

            builder.HasMany(x => x.Candidates).WithOne(x => x.BaseInfo).HasForeignKey(x => x.NationalityID);
        }
    }
}
