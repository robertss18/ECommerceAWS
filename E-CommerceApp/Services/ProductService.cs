using E_CommerceApp.Models;

namespace E_CommerceApp.Services
{
    public class ProductService
    {

        public static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "T-Shirt", Description = "Cotton t-shirt", Price = 19.99M, ImageUrl = "/images/tshirt.jpg" },
                new Product { Id = 2, Name = "Jeans", Description = "Blue denim jeans", Price = 39.99M, ImageUrl = "/images/jeans.jpg" },
                new Product { Id = 3, Name = "Sneakers", Description = "Running sneakers", Price = 59.99M, ImageUrl = "/images/sneakers.jpg" }
            };
        }

        public static Product? GetById(int id) =>
            GetProducts().FirstOrDefault(p => p.Id == id);

    }
}
