using eComApp.Application.Mapping;
using eComApp.Application.Products;
using Microsoft.Extensions.DependencyInjection;

namespace eComApp.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingConfig));
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();

        return services;
    }
}