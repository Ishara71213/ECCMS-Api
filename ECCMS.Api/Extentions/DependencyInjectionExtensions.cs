using ECCMS.Application.Services;
using ECCMS.Core.Interfaces.IRepositories;
using ECCMS.Core.Interfaces.IServices;
using ECCMS.Infrastructure.Data;
using ECCMS.Infrastructure.Repositories;

namespace ECCMS.Api.Extentions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<EccmsDbContext>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICityService, CityService>();


            return services;
        }
    }
}
