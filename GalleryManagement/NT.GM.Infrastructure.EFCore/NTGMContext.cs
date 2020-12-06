using Microsoft.EntityFrameworkCore;
using NT.GM.Domain.GalleryAgg;
using NT.GM.Infrastructure.EFCore.Mappings;

namespace NT.GM.Infrastructure.EFCore
{
    public class NTGMContext:DbContext
    {
        public DbSet<Gallery> Tbl_Gallery { get; set; }

        public NTGMContext(DbContextOptions<NTGMContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var assembly = typeof(GalleryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }

    }
}
