using eComApp.Domain.Abstract;
using eComApp.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace eComApp.Infrastructure;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
    : DbContext(options), IUnitOfWork
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}