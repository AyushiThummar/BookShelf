namespace BookShelf.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; } = 1;

        // Whose cart
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        // Book in cart (nullable because it could be ebook)
        public int? BookId { get; set; }
        public Book? Book { get; set; }

        // Ebook in cart (nullable because it could be book)
        public int? EbookId { get; set; }
        public Ebook? Ebook { get; set; }
    }
}