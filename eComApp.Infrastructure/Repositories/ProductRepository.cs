using eComApp.Domain.Products;

namespace eComApp.Infrastructure.Repositories;

internal class ProductRepository(ApplicationDbContext context) : Repository<Product>(context), IProductRepository
{
}
