using AutoMapper;
using eComApp.Application.DTOs;
using eComApp.Application.DTOs.Category;
using eComApp.Application.Exceptions;
using eComApp.Domain.Abstract;
using eComApp.Domain.Products;

namespace eComApp.Application.Products;

public class CategoryService(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : ICategoryService
{
    public async Task<IEnumerable<GetCategory>> GetAllAsync()
    {
        var categories = await categoryRepository.GetAllAsync();
        return mapper.Map<List<GetCategory>>(categories);
    }

    public async Task<GetCategory?> GetByIdAsync(Guid id)
    {
        var category = await categoryRepository.GetByIdAsync(id);
        return mapper.Map<GetCategory>(category);
    }

    public async Task<ServiceResponse> Add(CreateCategory category)
    {
        var mappedData = mapper.Map<Category>(category);
        categoryRepository.Add(mappedData);
        await unitOfWork.SaveChangesAsync();
        return new ServiceResponse(true, "Created Successfully");
    }

    public async Task<ServiceResponse> UpdateAsync(UpdateCategory category)
    {
        try
        {
            var mappedData = mapper.Map<Category>(category);
            categoryRepository.UpdateAsync(mappedData);
            await unitOfWork.SaveChangesAsync();
            return new ServiceResponse(true, "Updated Successfully");
        }
        catch (Exception e)
        {
            return new ServiceResponse(false, e.Message);
        }
    }

    public async Task<ServiceResponse> DeleteAsync(Guid id)
    {
        try
        {
            await categoryRepository.DeleteAsync(id);
            await unitOfWork.SaveChangesAsync();
            return new ServiceResponse(true, "Deleted Successfully");
        }
        catch (ItemNotFoundException e)
        {
            return new ServiceResponse(false, e.Message);
        }
    }
}