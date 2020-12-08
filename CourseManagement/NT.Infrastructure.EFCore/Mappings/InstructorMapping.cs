using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NT.CM.Domain.InstructorAgg;


namespace NT.CM.Infrastructure.EFCore.Mappings
{
    public class InstructorMapping : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            if (typeof(Instructor).BaseType == null)
            {
                builder.ToTable("Tbl_Instructor");
                builder.HasKey(x => x.ID);
                builder.Property(x => x.EducationLevel).HasMaxLength(100).IsRequired(false); ;
                builder.Property(x => x.Resume).IsRequired(false);
                builder.Property(x => x.Status);
                builder.Property(x => x.UserId);
                builder.HasMany(x => x.CourseInstructors).WithOne(x => x.Instructor).HasForeignKey(x => x.InstructorID);
            }
        }
    }
}
