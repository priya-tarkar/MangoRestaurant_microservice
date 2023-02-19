using Mango.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "Samosa",
                Price = 15,
                Description = "its tast good with spicy tast",
                ImageUrl = "https://micodotnet.blob.core.windows.net/mango/samosa.jpg",
                CategoryName = "Appetizer"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Paneer Tikka",
                Price = 13.99,
                Description = "hello this taste spicy and cold ",
                ImageUrl = "https://micodotnet.blob.core.windows.net/mango/Paneer%20tikka.jpg",
                CategoryName = "Appetizer"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "Sweet Pie",
                Price = 10.99,
                Description = "This is good in taste with heavy gulp and fried ",
                ImageUrl = "https://micodotnet.blob.core.windows.net/mango/sweet%20pie.jpg",
                CategoryName = "Dessert"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "Pav Bhaji",
                Price = 15,
                Description = "This is tasty with lots to full a stomach",
                ImageUrl = "https://micodotnet.blob.core.windows.net/mango/pav%20bhaji.jpg",
                CategoryName = "Entree"
            });
        }


    }
    
}
