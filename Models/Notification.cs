using System.ComponentModel.DataAnnotations;

namespace BookShelf.Models
{
    public class Notification
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        // "order", "offer", "system"
        public string Type { get; set; } = "system";

        // e.g. "2 mins ago", "Just now", "Yesterday"
        public string TimeAgo { get; set; } = "Just now";

        // true = unread, false = read
        public bool IsRead { get; set; } = false;

        // false = not dismissed, true = dismissed
        public bool IsDismissed { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Which user gets this notification
        // null = shown to ALL users (admin broadcast)
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}