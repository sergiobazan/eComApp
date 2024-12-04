using System.ComponentModel.DataAnnotations;

namespace eComApp.Application.DTOs.Category;

public class CreateCategory
{
    [Required]
    public string? Name { get; set; }
}