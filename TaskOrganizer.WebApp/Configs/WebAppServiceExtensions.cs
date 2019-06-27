using Microsoft.Extensions.DependencyInjection;
using TaskOrganizer.BLL.Services;
using TaskOrganizer.BLL.Services.Inerfaces;
using TaskOrganizer.DAL.Context;
using TaskOrganizer.DAL.Interfaces;
using TaskOrganizer.DataAccess.Repositories;

namespace TaskOrganizer.WebApp.Configs
{
    public static class WebAppServiceExtensions
    {
        public static IServiceCollection AddMyLibrary(this IServiceCollection services)
        {
            //services.Add<,> ();
            services.AddScoped<IDashboardService, DashBoardService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IMainObjectiveRepository, MainObjectiveRepository>();
            services.AddScoped<IChildObjectiveRepository, ChildObjectiveRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
