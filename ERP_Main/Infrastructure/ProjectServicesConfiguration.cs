using ERP_Data.Repository;
using ERP_Service;

namespace ERP_Main.Infrastructure
{
    public static class ProjectServicesConfiguration
    {
        public static IServiceCollection AddProjectRepositories(this IServiceCollection services)
        {
            return services
               .AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
        public static IServiceCollection AddProjectServices(this IServiceCollection services) =>
            services.AddScoped<IProductCategoryService, ProductCategoryService>();

    }
}
