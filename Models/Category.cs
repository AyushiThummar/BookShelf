using System.ComponentModel.DataAnnotations;

namespace BookShelf.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        // e.g. education_categoryy.png
        public string? ImagePath { get; set; }

        // Navigation
        public List<Book> Books { get; set; } = new();
        //public List<Ebook> Ebooks { get; set; } = new();
    }
}