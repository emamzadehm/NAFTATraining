using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NT.UM.Domain.UsersAgg;

namespace NT.UM.Infrastructure.EFCore.Mappings
{
    public class RolesMapping : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.ToTable("Tbl_Roles");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.RoleName);
            builder.Property(x => x.Description);
            builder.Property(x => x.Status);

            builder.HasMany(x => x.RolePermissions).WithOne(x => x.Roles).HasForeignKey(x => x.RoleID);
            //builder.OwnsMany(x => x.UsersRoless).OwnsOne(x => x.Roles,x=);

            builder.HasMany(x => x.UsersRoless).WithOne(x => x.Roles).HasForeignKey(x => x.RoleID);

        }
    }
}
