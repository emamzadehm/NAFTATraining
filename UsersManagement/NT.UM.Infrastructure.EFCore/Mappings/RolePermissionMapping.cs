using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NT.UM.Domain.UsersAgg;

namespace NT.UM.Infrastructure.EFCore.Mappings
{
    public class RolePermissionMapping : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.ToTable("Tbl_Role_Permission");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.RoleID);
            builder.Property(x => x.PermissionID);
            builder.Property(x => x.Status);
            builder.HasOne(x => x.Permissions).WithMany(x => x.RolePermissions).HasForeignKey(x => x.PermissionID);
            builder.HasOne(x => x.Roles).WithMany(x => x.RolePermissions).HasForeignKey(x => x.RoleID);
        }
    }
}
