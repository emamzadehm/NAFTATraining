using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NT.SM.Application;
using NT.SM.Application.Contracts.Interfaces;
using NT.SM.Domain.Interfaces;
using NT.SM.Infrastructure.EFCore;
using NT.SM.Infrastructure.EFCore.Repository;

namespace NT.SM.Infrastructure.Core
{
    public class SMBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionstring)
        {
            services.AddTransient<ISite_AboutApplication, Site_AboutApplication>();
            services.AddTransient<ISite_AboutRepository, Site_AboutRepository>();
            services.AddTransient<ISite_BaseApplication, Site_BaseApplication>();
            services.AddTransient<ISite_BaseRepository, Site_BaseRepository>();
            services.AddTransient<ISite_CertifiedProgramApplication, Site_CertifiedProgramApplication>();
            services.AddTransient<ISite_CertifiedProgramRepository, Site_CertifiedProgramRepository>();
            services.AddTransient<ISite_CourseApplication, Site_CourseApplication>();
            services.AddTransient<ISite_CourseRepository, Site_CourseRepository>();
            services.AddTransient<ISite_EvaluationResultApplication, Site_EvaluationResultApplication>();
            services.AddTransient<ISite_EvaluationResultRepository, Site_EvaluationResultRepository>();
            services.AddTransient<ISite_FacilityApplication, Site_FacilityApplication>();
            services.AddTransient<ISite_FacilityRepository, Site_FacilityRepository>();
            services.AddTransient<ISite_FAQApplication, Site_FAQApplication>();
            services.AddTransient<ISite_FAQRepository, Site_FAQRepository>();
            services.AddTransient<ISite_FunFactApplication, Site_FunFactApplication>();
            services.AddTransient<ISite_FunFactRepository, Site_FunFactRepository>();
            services.AddTransient<ISite_WhyNaftaApplication, Site_WhyNaftaApplication>();
            services.AddTransient<ISite_WhyNaftaRepository, Site_WhyNaftaRepository>();

            //services.AddTransient<ICourseQuery, CourseQuery>();

            services.AddTransient<IUnitOfWorkNTSM, UnitOfWorkNTSM>();

            services.AddDbContext<NTSMContext>(options => options.UseSqlServer(connectionstring));
        }
    }
}
