using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NT.SM.Domain.Models;

namespace NT.SM.Infrastructure.EFCore.Mapping
{
    public class Site_ClientAllianceMapping : IEntityTypeConfiguration<Site_ClientAlliance>
    {
        public void Configure(EntityTypeBuilder<Site_ClientAlliance> builder)
        {
            builder.ToTable("Site_ClientAlliance");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Name);
            builder.Property(x => x.Logo);
            builder.Property(x => x.Type);


            builder.Property(x => x.Site_Base_Id);
            builder.Property(x => x.Status);
            builder.Property(x => x.CreationDate);
            builder.HasOne(x => x.Sitebases).WithMany(x => x.Site_ClientAlliances).HasForeignKey(x => x.Site_Base_Id);
        }
    }
}
