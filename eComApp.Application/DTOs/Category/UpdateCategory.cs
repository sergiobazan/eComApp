using System.ComponentModel.DataAnnotations;

namespace eComApp.Application.DTOs.Category;

public class UpdateCategory
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public string? Name { get; set; }
}