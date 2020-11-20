using Microsoft.EntityFrameworkCore;
using NT.SM.Domain.Models;
using NT.SM.Infrastructure.EFCore.Mapping;

namespace NT.SM.Infrastructure.EFCore
{
    public class NTSMContext:DbContext
    {
        public DbSet<Site_About> Tbl_Site_About { get; set; }
        public DbSet<Site_Base> Tbl_Site_Base { get; set; }
        public DbSet<Site_CertifiedProgram> Tbl_Site_CertifiedProgram { get; set; }
        public DbSet<Site_Course> Tbl_Site_Course { get; set; }
        public DbSet<Site_EvaluationResult> Tbl_Site_EvaluationResult { get; set; }
        public DbSet<Site_Facility> Tbl_Site_Facility { get; set; }
        public DbSet<Site_FAQ> Tbl_Site_FAQ { get; set; }
        public DbSet<Site_FunFact> Tbl_Site_FunFact { get; set; }
        public DbSet<Site_WhyNafta> Tbl_Site_WhyNafta { get; set; }


        public NTSMContext(DbContextOptions<NTSMContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var assembly = typeof(Site_AboutMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

        }

    }
}
