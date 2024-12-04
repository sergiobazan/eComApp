using eComApp.Application.DTOs.Product;
using eComApp.Application.Products;
using Microsoft.AspNetCore.Mvc;

namespace eComApp.Presentation.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await productService.GetAllAsync();
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CreateProduct product)
    {
        var result = await productService.Add(product);
        return result.Success ? Ok(result) : BadRequest();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await productService.GetByIdAsync(id);
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateProduct product)
    {
        var result = await productService.UpdateAsync(product);
        return result.Success ? NoContent() : BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(Guid id)
    {
        var result = await productService.DeleteAsync(id);
        return result.Success ? NoContent() : NotFound();
    }
}
