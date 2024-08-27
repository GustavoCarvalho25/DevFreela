using DevFreela.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DevFreela.Application
{
    public static class ApplicationModule
    {
        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddScoped<IProjectService, ProjectService>();
            return services;
        }

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddServices();

            return services;
        }

    }
}
