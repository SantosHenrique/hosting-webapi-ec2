
using Microsoft.EntityFrameworkCore;
using Crud.Api.Entities;

namespace Crud.Api;

public class ProductDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
    }
}
