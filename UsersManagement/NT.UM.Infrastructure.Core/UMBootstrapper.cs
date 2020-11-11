using Microsoft.Extensions.DependencyInjection;
using NT.UM.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using NT.UM.Application.Contracts.Interfaces;
using NT.UM.Domain;
using NT.UM.Infrastructure.EFCore.Repositories;
using NT.UM.Application;
using _01.Framework.Domain;
using _01.Framework.Infrastructure.EFCore;

namespace NT.UM.Infrastructure.Core
{
    public class UMBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionstring)
        {

            services.AddTransient<IUserApplication, UserApplication>();
            services.AddTransient<IUsersRepository, UsersRepository>();

            //services.AddTransient<ICourseQuery, CourseQuery>();

            services.AddDbContext<NTUMContext>(options => options.UseSqlServer(connectionstring));
            services.AddTransient<IUnitOfWorkNTUM, UnitOfWorkNTUM>();

            //services.AddTransient<IUnitOfWork, UnitOfWorkUM>();
        }
    }
}
