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
                builder.Property(x => x.EducationLevel);
                builder.Property(x => x.Resume);
                builder.Property(x => x.Status);
                //builder.Property(x => x.Users.FirstName);
                //builder.Property(x => x.Users.LastName);
                //builder.Property(x => x.Users.Sex);
                //builder.Property(x => x.Users.Email);
                //builder.Property(x => x.Users.IMG);
                //builder.Property(x => x.Users.Tel);
                //builder.Property(x => x.Users.Password);
                //builder.Property(x => x.Users.Status);
                builder.HasMany(x => x.CourseInstructors).WithOne(x => x.Instructor).HasForeignKey(x => x.InstructorID);
            }
        }
    }
}
