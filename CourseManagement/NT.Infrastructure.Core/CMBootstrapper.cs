using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NT.CM.Domain;
using NT.CM.Infrastructure.EFCore;
using NT.CM.Infrastructure.EFCore.Repositories;
using NT.CM.Application.Contracts;
using NT.CM.Application;
using NT.CM.Application.Contracts.Interfaces;
using _01.Framework.Domain;
using NT.Infrastructure.Query.Interface;
using NT.Infrastructure.Query.Query;
using _01.Framework.Infrastructure.EFCore;

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

            services.AddTransient<IInstructorRepository, InstructorRepository>();

            services.AddTransient<ICandidateRepository, CandidateRepository>();

            services.AddTransient<ICourseQuery, CourseQuery>();
            //services.AddTransient<IUnitOfWorkNT, UnitOfWorkNT>();
            services.AddTransient<IUnitOfWorkNT, UnitOfWorkNT>();


            services.AddDbContext<NTContext>(x => x.UseSqlServer(connectionstring));
            //(options => options.UseSqlServer(connectionstring));
        }
    }
}
