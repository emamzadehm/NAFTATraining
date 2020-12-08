using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NT.CM.Domain.CandidateAgg;

namespace NT.CM.Infrastructure.EFCore.Mappings
{
    public class CandidateMapping : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            if (typeof(Candidate).BaseType == null)
            { 
                builder.ToTable("Tbl_Candidate");
                builder.HasKey(x => x.ID);
                builder.Property(x=>x.CompanyID).IsRequired(false);
                builder.Property(x => x.NID).HasMaxLength(20).IsRequired();
                builder.Property(x => x.DOB).HasMaxLength(10);
                builder.Property(x => x.NationalityID).IsRequired();
                builder.Property(x => x.CityOfBirth).HasMaxLength(100).IsRequired();
                builder.Property(x => x.Status);
                builder.Property(x => x.UserId);

                //builder.Property(x => x.Users);
                //builder.
                builder.HasMany(x => x.CandidateCourseInstructors).WithOne(x=>x.Candidates).HasForeignKey(x=>x.CandidateID);
                builder.HasOne(x => x.Company).WithMany(x => x.Candidates).HasForeignKey(x => x.CompanyID);
                builder.HasOne(x => x.BaseInfo).WithMany(x => x.Candidates).HasForeignKey(x => x.NationalityID);
            }


        }
    }
}
