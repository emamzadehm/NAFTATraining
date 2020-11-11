using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NT.CM.Domain.CompanyAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.CM.Infrastructure.EFCore.Mappings
{
    public class CompanyMapping : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Tbl_Companies");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.CompanyName);
            builder.Property(x => x.Website);
            builder.Property(x => x.Logo);
            builder.Property(x => x.TypeID);
            builder.Property(x => x.Status);
            builder.HasMany(x => x.Candidates).WithOne(x => x.Company).HasForeignKey(x => x.CompanyID);
            builder.HasOne(x => x.BaseInfo).WithMany(x => x.Companies).HasForeignKey(x => x.TypeID);
        }
    }
}
