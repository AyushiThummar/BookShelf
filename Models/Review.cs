using System.ComponentModel.DataAnnotations;

namespace BookShelf.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        public string Comment { get; set; }

        // 1 to 5 stars
        public int Rating { get; set; } = 5;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Which book
        public int BookId { get; set; }
        public Book? Book { get; set; }

        // Who wrote this review
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}