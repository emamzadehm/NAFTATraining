using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NT.CM.Domain.CandidateCourseInstructorAgg;

namespace NT.CM.Infrastructure.EFCore.Mappings
{
    public class CandidateCourseInstructorMapping : IEntityTypeConfiguration<CandidateCourseInstructor>
    {
        public void Configure(EntityTypeBuilder<CandidateCourseInstructor> builder)
        {
            builder.ToTable("Tbl_Candidate_Course_Instructor");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Course_InstructorID).IsRequired(); ;
            builder.Property(x => x.CandidateID).IsRequired();
            builder.Property(x => x.RegistrationDate);
            builder.Property(x => x.Status);
            builder.HasMany(x => x.CourseCandidateInstructorDetailss).WithOne(x=>x.CandidateCourseInstructor).HasForeignKey(x=>x.CCI_ID);
            builder.HasOne(x => x.CourseInstructors).WithMany(x => x.CandidateCourseInstructors).HasForeignKey(x => x.Course_InstructorID);
            builder.HasOne(x => x.Candidates).WithMany(x => x.CandidateCourseInstructors).HasForeignKey(x => x.CandidateID);
        }
    }
}
