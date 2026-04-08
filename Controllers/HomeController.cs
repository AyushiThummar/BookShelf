using System.Diagnostics;
using BookShelf.Models;
using Microsoft.AspNetCore.Mvc;
using BookShelf.Data;
using Microsoft.EntityFrameworkCore;

namespace BookShelf.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Category()
        {
            return View();
        }
        public IActionResult BookDetails(int id)
        {
            var book = _db.Books
                .Include(b => b.Category)
                .Include(b => b.Uploader)
                .Include(b => b.Reviews)
                .FirstOrDefault(b => b.Id == id);

            if (book == null) return NotFound();

            return View(book);
        }
        public IActionResult Ebooks()
        {
            return View();
        }
        public IActionResult EbookDetails()
        {
            return View();
        }
        public IActionResult CategoryBooks(string category)
        {
            ViewBag.Category = category ?? "Books";
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> UploaderInfo(int id)
        {
            var book = await _db.Books
                .Include(b => b.Uploader)
                .FirstOrDefaultAsync(b => b.Id == id);

            return View(book);
        }
    }
}
