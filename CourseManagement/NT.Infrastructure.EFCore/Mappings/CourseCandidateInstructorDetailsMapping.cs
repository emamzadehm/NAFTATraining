using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NT.CM.Domain.CourseCandidateInstructorDetailsAgg;

namespace NT.CM.Infrastructure.EFCore.Mappings
{
    class CourseCandidateInstructorDetailsMapping : IEntityTypeConfiguration<CourseCandidateInstructorDetails>
    {
        public void Configure(EntityTypeBuilder<CourseCandidateInstructorDetails> builder)
        {
            builder.ToTable("Tbl_Course_Candidate_Instuctor_Details");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.TypeID);
            builder.Property(x => x.Value);
            builder.Property(x => x.DocumentIMG);
            builder.Property(x => x.CCI_ID);
            builder.Property(x => x.Status);
            builder.HasOne(x => x.CandidateCourseInstructor).WithMany(x => x.CourseCandidateInstructorDetailss).HasForeignKey(x => x.CCI_ID);
            builder.HasOne(x => x.BaseInfo).WithMany(x => x.CourseCandidateInstructorDetails).HasForeignKey(x => x.TypeID);
        }
    }
}
