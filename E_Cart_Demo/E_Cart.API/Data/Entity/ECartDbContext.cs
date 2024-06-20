using ECart.API.Data.Entity.DbSet;
using Microsoft.EntityFrameworkCore;

namespace ECart.API.Data.Entity;
public class ECartDbContext: DbContext
{
    public ECartDbContext(DbContextOptions<ECartDbContext> options)
          : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
}

