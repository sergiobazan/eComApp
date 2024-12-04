using AutoMapper;
using eComApp.Application.DTOs;
using eComApp.Application.DTOs.Product;
using eComApp.Application.Exceptions;
using eComApp.Domain.Abstract;
using eComApp.Domain.Products;

namespace eComApp.Application.Products;

public class ProductService(
    IProductRepository productRepository, 
    IUnitOfWork unitOfWork,
    IMapper mapper) : IProductService
{
    public async Task<IEnumerable<GetProduct>> GetAllAsync()
    {
        var products = await productRepository.GetAllAsync();
        return mapper.Map<List<GetProduct>>(products);
    }

    public async Task<GetProduct?> GetByIdAsync(Guid id)
    {
        var product = await productRepository.GetByIdAsync(id);
        return mapper.Map<GetProduct>(product);
    }

    public async Task<ServiceResponse> Add(CreateProduct product)
    {
        var mappedData = mapper.Map<Product>(product);
        productRepository.Add(mappedData);
        await unitOfWork.SaveChangesAsync();
        return new ServiceResponse(true, "Created Successfully");
    }

    public async Task<ServiceResponse> UpdateAsync(UpdateProduct product)
    {
        try
        {
            var mappedData = mapper.Map<Product>(product);
            productRepository.UpdateAsync(mappedData);
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
            await productRepository.DeleteAsync(id);
            await unitOfWork.SaveChangesAsync();
            return new ServiceResponse(true, "Deleted Successfully");
        }
        catch (ItemNotFoundException e)
        {
            return new ServiceResponse(false, e.Message);
        }
        
    }
}