using E_CommerceApp.Models;
using Microsoft.EntityFrameworkCore;


namespace E_CommerceApp.AppDbContext
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Order> Orders { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasPrecision(18, 2);

            // Seed data: 5 sample products
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Wireless Mouse",
                    Description = "Ergonomic wireless mouse with USB receiver.",
                    Price = 19.99m,
                    ImageUrl = "/images/mouse.jpg"
                },
                new Product
                {
                    Id = 2,
                    Name = "Mechanical Keyboard",
                    Description = "RGB mechanical keyboard with blue switches.",
                    Price = 59.99m,
                    ImageUrl = "/images/keyboard.jpg"
                },
                new Product
                {
                    Id = 3,
                    Name = "HD Webcam",
                    Description = "1080p webcam with microphone for streaming.",
                    Price = 39.99m,
                    ImageUrl = "/images/webcam.jpg"
                },
                new Product
                {
                    Id = 4,
                    Name = "Laptop Stand",
                    Description = "Adjustable aluminum laptop stand.",
                    Price = 29.99m,
                    ImageUrl = "/images/laptopstand.jpg"
                },
                new Product
                {
                    Id = 5,
                    Name = "USB-C Hub",
                    Description = "Multiport hub with HDMI, USB, and SD card reader.",
                    Price = 34.99m,
                    ImageUrl = "/images/hub.jpg"
                }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    CustomerName = "Alice Johnson",
                    CustomerEmail = "alice@example.com",
                    OrderDate = new DateTime(2024, 05, 10)
                },
                new Order
                {
                    Id = 2,
                    CustomerName = "Bob Smith",
                    CustomerEmail = "bob@example.com",
                    OrderDate = new DateTime(2024, 05, 15)
                },
                new Order
                {
                    Id = 3,
                    CustomerName = "Carol Martinez",
                    CustomerEmail = "carol@example.com",
                    OrderDate = new DateTime(2024, 05, 20)
                }
            );

            // Seed: CartItems associated with Orders
            modelBuilder.Entity<CartItem>().HasData(
                new CartItem
                {
                    Id = 1,
                    ProductId = 1, // Wireless Mouse
                    Quantity = 2,
                    OrderId = 1
                },
                new CartItem
                {
                    Id = 2,
                    ProductId = 3, // HD Webcam
                    Quantity = 1,
                    OrderId = 1
                },
                new CartItem
                {
                    Id = 3,
                    ProductId = 2, // Mechanical Keyboard
                    Quantity = 1,
                    OrderId = 2
                },
                new CartItem
                {
                    Id = 4,
                    ProductId = 4, // Laptop Stand
                    Quantity = 1,
                    OrderId = 3
                },
                new CartItem
                {
                    Id = 5,
                    ProductId = 5, // USB-C Hub
                    Quantity = 2,
                    OrderId = 3
                }
            );
        }

    }
}
