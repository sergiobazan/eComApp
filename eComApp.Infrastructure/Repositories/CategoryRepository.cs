using eComApp.Domain.Products;

namespace eComApp.Infrastructure.Repositories;

public class CategoryRepository(ApplicationDbContext context) : Repository<Category>(context), ICategoryRepository
{
    
}