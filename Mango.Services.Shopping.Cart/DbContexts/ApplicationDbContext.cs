using Mango.Services.Shopping.Cart.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.Shopping.Cart.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartHeader> CartHeaders { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
    }
}
