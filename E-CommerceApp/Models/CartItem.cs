using System.ComponentModel.DataAnnotations;

namespace E_CommerceApp.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }

        // FK to Product
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        // Quantity of this product
        public int Quantity { get; set; }

        // Optional: FK to an Order (when user places the order)
        public int? OrderId { get; set; }
        public Order? Order { get; set; }


    }
}
