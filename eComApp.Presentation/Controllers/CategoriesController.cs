using eComApp.Application.DTOs.Category;
using eComApp.Application.Products;
using Microsoft.AspNetCore.Mvc;

namespace eComApp.Presentation.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoriesController(ICategoryService categoryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await categoryService.GetAllAsync();
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CreateCategory category)
    {
        var result = await categoryService.Add(category);
        return result.Success ? Ok(result) : BadRequest();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await categoryService.GetByIdAsync(id);
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCategory category)
    {
        var result = await categoryService.UpdateAsync(category);
        return result.Success ? NoContent() : BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(Guid id)
    {
        var result = await categoryService.DeleteAsync(id);
        return result.Success ? NoContent() : NotFound();
    }
}
