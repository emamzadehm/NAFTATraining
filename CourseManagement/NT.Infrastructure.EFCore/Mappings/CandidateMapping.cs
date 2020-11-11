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
                builder.Property(x=>x.CompanyID);
                builder.Property(x => x.NID);
                builder.Property(x => x.DOB);
                builder.Property(x => x.NationalityID);
                builder.Property(x => x.CityOfBirth);
                builder.Property(x => x.Status);
                //builder.Property(x => x.Users);
                //builder.
                builder.HasMany(x => x.CandidateCourseInstructors).WithOne(x=>x.Candidates).HasForeignKey(x=>x.CandidateID);
                builder.HasOne(x => x.Company).WithMany(x => x.Candidates).HasForeignKey(x => x.CompanyID);
                builder.HasOne(x => x.BaseInfo).WithMany(x => x.Candidates).HasForeignKey(x => x.NationalityID);
            }


        }
    }
}
