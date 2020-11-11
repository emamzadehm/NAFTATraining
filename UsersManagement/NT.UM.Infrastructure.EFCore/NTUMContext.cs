using Microsoft.EntityFrameworkCore;
using NT.UM.Domain.UsersAgg;
using NT.UM.Infrastructure.EFCore.Mappings;

namespace NT.UM.Infrastructure.EFCore
{
    public class NTUMContext:DbContext
    {

        public DbSet<Users> Tbl_Users { get; set; }
        public DbSet<Roles> Tbl_Roles { get; set; }
        public DbSet<Permissions> Tbl_Permissions { get; set; }
        public DbSet<RolePermission> Tbl_Role_Permission { get; set; }
        public DbSet<UsersRoles> Tbl_Users_Roles { get; set; }
        

        public NTUMContext(DbContextOptions<NTUMContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var assembly = typeof(PermissionsMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            //modelBuilder.ApplyConfiguration(new CourseMapping());
            //modelBuilder.ApplyConfiguration(new CandidateMapping());
            //modelBuilder.ApplyConfiguration(new CourseCandidateMapping());
        }

    }
}
