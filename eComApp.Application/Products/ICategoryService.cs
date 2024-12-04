using eComApp.Application.DTOs;
using eComApp.Application.DTOs.Category;

namespace eComApp.Application.Products;

public interface ICategoryService
{
    Task<IEnumerable<GetCategory>> GetAllAsync();
    Task<GetCategory?> GetByIdAsync(Guid id);
    Task<ServiceResponse> Add(CreateCategory category);
    Task<ServiceResponse> UpdateAsync(UpdateCategory category);
    Task<ServiceResponse> DeleteAsync(Guid id);
}