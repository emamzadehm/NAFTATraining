using Microsoft.EntityFrameworkCore;
using NT.UM.Domain.UsersAgg;
using NT.UM.Infrastructure.EFCore.Mappings;

namespace NT.UM.Infrastructure.EFCore
{
    public class NTUMContext:DbContext
    {

        public DbSet<User> Tbl_Users { get; set; }
        public DbSet<Role> Tbl_Roles { get; set; }
        public DbSet<Permission> Tbl_Permissions { get; set; }
        public DbSet<RolePermission> Tbl_Role_Permission { get; set; }
        public DbSet<UserRole> Tbl_Users_Roles { get; set; }

        public NTUMContext(DbContextOptions<NTUMContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var assembly = typeof(UsersMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }

    }
}
