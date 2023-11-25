using Microsoft.EntityFrameworkCore;
using Shop.Domain;

namespace Shop.Infrastructure.Data;

public class AplicationDbContext : DbContext
{
    public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product()
            {
                Id = 1,
                Name = "fortoxali",
                Description = "axali",
                Price = 5,
                quantity = 5,

            },
            new Product()
            {
                Id = 2,
                Name = "fortoxali",
                Description = "axali",
                Price = 5,
                quantity = 5,

            });
    }
}
