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
            services.AddSingleton(new Random());
            services.AddScoped<EccmsDbContext>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICityService, CityService>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IBranchService, BranchService>();

            services.AddScoped<ICrimeTypeRepository, CrimeTypeRepository>();
            services.AddScoped<ICrimeTypeService, CrimeTypeService>();

            services.AddScoped<IInquiryRepository, InquiryRepository>();
            services.AddScoped<IInquiryService, InquiryService>();
            
            services.AddScoped<IInstitutionRepository, InstitutionRepository>();
            services.AddScoped<IInstitutionService, InstitutionService>();


            return services;
        }
    }
}
