using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NT.UM.Domain.UsersAgg;

namespace NT.UM.Infrastructure.EFCore.Mappings
{
    public class PermissionsMapping : IEntityTypeConfiguration<Permissions>
    {
        public void Configure(EntityTypeBuilder<Permissions> builder)
        {
            builder.ToTable("Tbl_Permissions");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Title).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Status);
            builder.HasMany(x => x.RolePermissions).WithOne(x => x.Permissions).HasForeignKey(x => x.PermissionID);
        }
    }
}
