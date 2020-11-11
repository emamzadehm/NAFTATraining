using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NT.SM.Domain.Models;

namespace NT.SM.Infrastructure.EFCore.Mapping
{
    public class Site_CourseMapping : IEntityTypeConfiguration<Site_Course>
    {
        public void Configure(EntityTypeBuilder<Site_Course> builder)
        {
            builder.ToTable("Site_Course");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Icon);
            builder.Property(x => x.Title);
            builder.Property(x => x.Description);


            builder.Property(x => x.Site_Base_Id);
            builder.Property(x => x.Status);
            builder.Property(x => x.CreationDate);
            builder.HasOne(x => x.Sitebases).WithMany(x => x.Site_Courses).HasForeignKey(x => x.Site_Base_Id);
        }
    }
}
