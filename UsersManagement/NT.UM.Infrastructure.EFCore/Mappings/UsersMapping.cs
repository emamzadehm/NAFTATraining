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
            builder.Property(x => x.FirstName).HasMaxLength(200).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Tel).HasMaxLength(200).IsRequired(false);
            builder.Property(x => x.IMG).HasMaxLength(2000).IsRequired(false);
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.IDCardIMG).HasMaxLength(2000).IsRequired(false);
            builder.Property(x => x.Status);

            builder.HasMany(x => x.UsersRoless).WithOne(x => x.Users).HasForeignKey(x => x.UserID);
            //builder.HasOne<Candidate>(x=>x.Candidates).WithOne(x=>x.Users).HasForeignKey<Candidate>(x=>x.ID);
            //builder.HasOne<Instructor>(x => x.Instructors).WithOne(x => x.Users).HasForeignKey<Instructor>(x => x.ID);
        }
    }
}
