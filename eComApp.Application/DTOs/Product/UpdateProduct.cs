using System.ComponentModel.DataAnnotations;

namespace eComApp.Application.DTOs.Product;

public class UpdateProduct : ProductBase
{
    [Required]
    public Guid Id { get; set; }
}