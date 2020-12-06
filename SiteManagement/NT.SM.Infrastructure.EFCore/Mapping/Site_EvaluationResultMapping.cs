using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NT.SM.Domain.Models;

namespace NT.SM.Infrastructure.EFCore.Mapping
{
    public class Site_EvaluationResultMapping : IEntityTypeConfiguration<Site_EvaluationResult>
    {
        public void Configure(EntityTypeBuilder<Site_EvaluationResult> builder)
        {
            builder.ToTable("Site_EvaluationResult");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Title);
            builder.Property(x => x.Percentage);


            builder.Property(x => x.Status);
            builder.Property(x => x.CreationDate);
        }
    }
}