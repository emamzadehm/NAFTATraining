using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NT.SM.Domain.Models;

namespace NT.SM.Infrastructure.EFCore.Mapping
{
    public class Site_BaseMapping : IEntityTypeConfiguration<Site_Base>
    {
        public void Configure(EntityTypeBuilder<Site_Base> builder)
        {
            builder.ToTable("Site_Base");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.MainTitle);
            builder.Property(x => x.MainDescription);
            builder.Property(x => x.Status);
            builder.Property(x => x.CreationDate);
            builder.HasMany(x => x.Site_Abouts).WithOne(x => x.Sitebases).HasForeignKey(x => x.Site_Base_Id);
        }
    }
}
