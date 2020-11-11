using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NT.UM.Domain.UsersAgg;

namespace NT.UM.Infrastructure.EFCore.Mappings
{
    public class UsersRolesMapping : IEntityTypeConfiguration<UsersRoles>
    {
        public void Configure(EntityTypeBuilder<UsersRoles> builder)
        {
            builder.ToTable("Tbl_Users_Roles");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.UserID);
            builder.Property(x => x.RoleID);
            builder.Property(x => x.Status);
            builder.HasOne(x => x.Users).WithMany(x => x.UsersRoless).HasForeignKey(x => x.UserID);
            builder.HasOne(x => x.Roles).WithMany(x => x.UsersRoless).HasForeignKey(x => x.RoleID);

        }
    }
}
