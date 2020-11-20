using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NT.CM.Domain;
using NT.CM.Infrastructure.EFCore;
using NT.CM.Infrastructure.EFCore.Repositories;
using NT.CM.Application.Contracts;
using NT.CM.Application;
using NT.CM.Application.Contracts.Interfaces;
using NT.Infrastructure.Query.Interface;
using NT.Infrastructure.Query.Query;

namespace NT.CM.Infrastructure.Core
{
    public class CMBootstrapper
    {
        
        public static void Configure(IServiceCollection services, string connectionstring)
        {
            services.AddTransient<ICourseApplication, CourseApplication>();
            services.AddTransient<ICourseRepository, CourseRepository>();

            services.AddTransient<ICandidateApplication, CandidateApplication>();
            services.AddTransient<ICandidateRepository, CandidateRepository>();

            services.AddTransient<IBaseInfoApplication, BaseInfoApplication>();
            services.AddTransient<IBaseInfoRepository, BaseInfoRepository>();

            services.AddTransient<ICompanyApplication, CompanyApplication>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();

            services.AddTransient<IGalleryApplication, GalleryApplication>();
            services.AddTransient<IGalleryRepository, GalleryRepository>();

            services.AddTransient<ICourseInstructorApplication, CourseInstructorApplication>();
            services.AddTransient<ICourseInstructorRepository, CourseInstructorRepository>();

            services.AddTransient<IInstructorApplication, InstructorApplication>();
            services.AddTransient<IInstructorRepository, InstructorRepository>();

            services.AddTransient<ICandidateCourseInstructorApplication, CandidateCourseInstructorApplication>();
            services.AddTransient<ICandidateCourseInstructorRepository, CandidateCourseInstructorRepository>();

            services.AddTransient<ICourseCandidateInstructorDetailsApplication, CourseCandidateInstructorDetailsApplication>();
            services.AddTransient<ICourseCandidateInstructorDetailsRepository, CourseCandidateInstructorDetailsRepository>();

            services.AddTransient<ICourseQuery, CourseQuery>();

            services.AddTransient<IUnitOfWorkNT, UnitOfWorkNT>();

            services.AddDbContext<NTContext>(x => x.UseSqlServer(connectionstring));
        }
    }
}
