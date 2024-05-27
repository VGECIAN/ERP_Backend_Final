using ERP_Service;

namespace ERP_Main.Infrastructure
{
    public static class ProjectServicesConfiguration
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services) =>
            services.AddScoped<IProductCategoryService, ProductCategoryService>();

    }
}
