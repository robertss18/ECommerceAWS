using System.ComponentModel.DataAnnotations;

namespace E_CommerceApp.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;

        [DataType(DataType.Date)] // Indica que es solo una fecha
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        // One-to-many: an Order has multiple CartItems
        public List<CartItem> CartItems { get; set; } = new();

    }
}
