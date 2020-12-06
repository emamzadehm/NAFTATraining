using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NT.SM.Domain.Models;

namespace NT.SM.Infrastructure.EFCore.Mapping
{
    public class Site_WhyNaftaMapping : IEntityTypeConfiguration<Site_WhyNafta>
    {
        public void Configure(EntityTypeBuilder<Site_WhyNafta> builder)
        {
            builder.ToTable("Site_WhyNafta");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Description);



            builder.Property(x => x.Site_Base_Id);
            builder.Property(x => x.Status);
            builder.Property(x => x.CreationDate);
            builder.HasOne(x => x.Sitebases).WithMany(x => x.Site_WhyNaftas).HasForeignKey(x => x.Site_Base_Id);
        }
    }
}