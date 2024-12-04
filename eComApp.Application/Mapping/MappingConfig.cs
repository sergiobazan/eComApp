using AutoMapper;
using eComApp.Application.DTOs.Category;
using eComApp.Application.DTOs.Product;
using eComApp.Domain.Products;

namespace eComApp.Application.Mapping;
public class MappingConfig: Profile
{
    public MappingConfig()
    {
        CreateMap<CreateCategory, Category>();
        CreateMap<CreateProduct, Product>();

        CreateMap<GetCategory, Category>();
        CreateMap<Category, GetCategory>();

        CreateMap<GetProduct, Product>();
        CreateMap<Product, GetProduct>();

        CreateMap<Category, CreateCategory>();
        CreateMap<Product, CreateProduct>();

    }
}
