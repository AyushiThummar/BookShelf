using BookShelf.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace BookShelf.Models
{
    public class Order
    {
        public int Id { get; set; }

        // e.g. BK10234
        public string? OrderNumber { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }

        // Pending, Processing, Delivered, Cancelled
        public string Status { get; set; } = "Pending";

        // Always COD in your website
        public string PaymentMethod { get; set; } = "Cash on Delivery";

        // Delivery address
        public string? ShippingAddress { get; set; }

        // Who placed the order
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        // Order items
        public List<OrderItem> OrderItems { get; set; } = new();
    }
}