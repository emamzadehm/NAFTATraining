using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NT.SM.Domain.Models;

namespace NT.SM.Infrastructure.EFCore.Mapping
{
    public class Site_FAQResultMapping : IEntityTypeConfiguration<Site_FAQ>
    {
        public void Configure(EntityTypeBuilder<Site_FAQ> builder)
        {
            builder.ToTable("Site_FAQ");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Question);
            builder.Property(x => x.Answer);


            builder.Property(x => x.Status);
            builder.Property(x => x.CreationDate);
        }
    }
}