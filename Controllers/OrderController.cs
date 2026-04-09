using BookShelf.Data;
using BookShelf.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookShelf.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;

        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult OrderSuccess()
        {
            return View();
        }

        public IActionResult Orders()
        {
            return View();
        }

        public IActionResult Wishlist()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Account/Login");
            }

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            var wishlist = _db.WishlistItems
                .Where(w => w.UserId == userId)
                .Include(w => w.Book)
                .ThenInclude(b => b.Category)
                .ToList();

            return View(wishlist);
        }

        [HttpPost]
        public async Task<IActionResult> ToggleWishlist(int bookId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Account/Login");
            }

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            var item = _db.WishlistItems
                .FirstOrDefault(w => w.BookId == bookId && w.UserId == userId);

            if (item != null)
            {
                _db.WishlistItems.Remove(item); // REMOVE
            }
            else
            { 
                _db.WishlistItems.Add(new WishlistItem
                {
                    BookId = bookId,
                    UserId = userId
                }); // ADD
            }

            await _db.SaveChangesAsync();

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}