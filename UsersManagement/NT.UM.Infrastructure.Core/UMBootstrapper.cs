using Microsoft.Extensions.DependencyInjection;
using NT.UM.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using NT.UM.Application.Contracts.Interfaces;
using NT.UM.Domain;
using NT.UM.Infrastructure.EFCore.Repositories;
using NT.UM.Application;

namespace NT.UM.Infrastructure.Core
{
    public class UMBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionstring)
        {

            services.AddTransient<IUserApplication, UserApplication>();
            services.AddTransient<IUsersRepository, UsersRepository>();

            services.AddTransient<IRolesApplication, RolesApplication>();
            services.AddTransient<IRolesRepository, RolesRepository>();

            services.AddTransient<IRolePermissionApplication, RolePermissionApplication>();
            services.AddTransient<IRolePermissionRepository, RolePermissionRepository>();

            services.AddTransient<IPermissionsApplication, PermissionsApplication>();
            services.AddTransient<IPermissionsRepository, PermissionsRepository>();

            services.AddTransient<IUsersRolesRepository, UsersRolesRepository>();

            services.AddTransient<IPermissionTypes, PermissionTypes>();



            //services.AddTransient<ICourseQuery, CourseQuery>();

            services.AddDbContext<NTUMContext>(options => options.UseSqlServer(connectionstring));
            services.AddTransient<IUnitOfWorkNTUM, UnitOfWorkNTUM>();
        }
    }
}
