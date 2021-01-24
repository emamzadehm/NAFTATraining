using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NT.UM.Domain.UsersAgg;

namespace NT.UM.Infrastructure.EFCore.Mappings
{
    public class PermissionsMapping : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Tbl_Permissions");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Title).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Status);

            //builder.HasOne(x => x.ParentId).WithMany(x => x.).HasForeignKey(x => x.ParentID);

            builder.HasMany(x => x.Permissions).WithOne(x => x.permission).HasForeignKey(x => x.ParentId);

            builder.HasMany(x => x.RolePermissions).WithOne(x => x.Permissions).HasForeignKey(x => x.PermissionID);
        }
    }
}
