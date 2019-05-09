using Microsoft.Extensions.DependencyInjection;

namespace TaskOrganizer.WebApp.Configs
{
    public static class WebAppServiceExtensions
    {
        public static IServiceCollection AddMyLibrary(this IServiceCollection services)
        {
            //services.Add<,> ();
            return services;
        }
    }
}
