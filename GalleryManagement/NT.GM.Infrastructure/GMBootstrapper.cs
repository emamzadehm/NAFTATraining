using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NT.GM.Application;
using NT.GM.Application.Contracts.Interfaces;
using NT.GM.Domain;
using NT.GM.Infrastructure.EFCore;
using NT.GM.Infrastructure.EFCore.Repositories;

namespace NT.GM.Infrastructure
{
    public class GMBootstrapper
    {
        
        public static void Configure(IServiceCollection services, string connectionstring)
        {
            services.AddTransient<IGalleryApplication, GalleryApplication>();
            services.AddTransient<IGalleryRepository, GalleryRepository>();

            //services.AddTransient<ICourseQuery, CourseQuery>();

            services.AddTransient<IUnitOfWorkNTGM, UnitOfWorkNTGM>();

            services.AddDbContext<NTGMContext>(x => x.UseSqlServer(connectionstring));
        }
    }
}
