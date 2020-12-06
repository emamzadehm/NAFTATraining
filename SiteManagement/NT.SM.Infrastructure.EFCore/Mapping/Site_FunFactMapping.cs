using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NT.SM.Domain.Models;

namespace NT.SM.Infrastructure.EFCore.Mapping
{
    public class Site_FunFactMapping : IEntityTypeConfiguration<Site_FunFact>
    {
        public void Configure(EntityTypeBuilder<Site_FunFact> builder)
        {
            builder.ToTable("Site_FunFact");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Title);
            builder.Property(x => x.ValueNumber);


            builder.Property(x => x.Status);
            builder.Property(x => x.CreationDate);
        }
    }
}