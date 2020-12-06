using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NT.SM.Domain.Models;

namespace NT.SM.Infrastructure.EFCore.Mapping
{
    public class Site_CertifiedProgramMapping : IEntityTypeConfiguration<Site_CertifiedProgram>
    {
        public void Configure(EntityTypeBuilder<Site_CertifiedProgram> builder)
        {
            builder.ToTable("Site_CertifiedProgram");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Logo);
            builder.Property(x => x.Title);
            builder.Property(x => x.ShortDescription);
            builder.Property(x => x.Description);



            builder.Property(x => x.Site_Base_Id);
            builder.Property(x => x.Status);
            builder.Property(x => x.CreationDate);
            builder.HasOne(x => x.Sitebases).WithMany(x => x.Site_CertifiedPrograms).HasForeignKey(x => x.Site_Base_Id);
        }
    }
}