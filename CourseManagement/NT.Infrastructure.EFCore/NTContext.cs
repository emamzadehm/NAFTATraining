using Domain.BaseInfoAgg;
using Microsoft.EntityFrameworkCore;
using NT.CM.Domain.CandidateAgg;
using NT.CM.Domain.CandidateCourseInstructorAgg;
using NT.CM.Domain.CompanyAgg;
using NT.CM.Domain.CourseAgg;
using NT.CM.Domain.CourseCandidateInstructorDetailsAgg;
using NT.CM.Domain.CourseInstructorAgg;
using NT.CM.Domain.GalleryAgg;
using NT.CM.Domain.InstructorAgg;
using NT.CM.Infrastructure.EFCore.Mappings;

namespace NT.CM.Infrastructure.EFCore
{
    public class NTContext:DbContext
    {
        public DbSet<BaseInfo> Tbl_Base_Info { get; set; }
        public DbSet<Course> Tbl_Course { get; set; }
        public DbSet<Instructor> Tbl_Instructor { get; set; }
        public DbSet<CourseInstructor> Tbl_Course_Instructor { get; set; }
        public DbSet<CandidateCourseInstructor> Tbl_Candidate_Course_Instructor { get; set; }
        public DbSet<Candidate> Tbl_Candidate { get; set; }
        public DbSet<Company> Tbl_Companies { get; set; }
        public DbSet<Gallery> Tbl_Gallery { get; set; }
        public DbSet<CourseCandidateInstructorDetails> Tbl_Course_Candidate_Instructor_Details { get; set; }

        public NTContext(DbContextOptions<NTContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var assembly = typeof(CourseMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            //modelBuilder.ApplyConfiguration(new CourseMapping());
            //modelBuilder.ApplyConfiguration(new CandidateMapping());
            //modelBuilder.ApplyConfiguration(new CourseCandidateMapping());
        }

    }
}
