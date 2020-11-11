using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NT.UM.Domain.UsersAgg;

namespace NT.UM.Infrastructure.EFCore.Mappings
{
    public class UsersMapping : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("Tbl_Users");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.FirstName);
            builder.Property(x => x.LastName);
            builder.Property(x => x.Email);
            builder.Property(x => x.Tel);
            builder.Property(x => x.IMG);
            builder.Property(x => x.Password);
            builder.Property(x => x.IDCardIMG);
            builder.Property(x => x.Status);

            builder.HasMany(x => x.UsersRoless).WithOne(x => x.Users).HasForeignKey(x => x.UserID);
            //builder.HasOne<Candidate>(x=>x.Candidates).WithOne(x=>x.Users).HasForeignKey<Candidate>(x=>x.ID);
            //builder.HasOne<Instructor>(x => x.Instructors).WithOne(x => x.Users).HasForeignKey<Instructor>(x => x.ID);
        }
    }
}
