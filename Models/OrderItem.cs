namespace BookShelf.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal Price { get; set; }

        // Which order this belongs to
        public int OrderId { get; set; }
        public Order? Order { get; set; }

        // Either a Book OR an Ebook
        public int? BookId { get; set; }
        public Book? Book { get; set; }

        public int? EbookId { get; set; }
        public Ebook? Ebook { get; set; }
    }
}