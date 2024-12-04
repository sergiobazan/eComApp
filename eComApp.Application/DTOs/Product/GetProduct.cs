using eComApp.Application.DTOs.Category;

namespace eComApp.Application.DTOs.Product;

public class GetProduct : ProductBase
{
    public Guid Id { get; set; }
    public GetCategory? Category { get; set; }
}