using eComApp.Application.DTOs;
using eComApp.Application.DTOs.Product;

namespace eComApp.Application.Products;

public interface IProductService
{
    Task<IEnumerable<GetProduct>> GetAllAsync();
    Task<GetProduct?> GetByIdAsync(Guid id);
    Task<ServiceResponse> Add(CreateProduct product);
    Task<ServiceResponse> UpdateAsync(UpdateProduct product);
    Task<ServiceResponse> DeleteAsync(Guid id);
}