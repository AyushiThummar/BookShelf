using Microsoft.AspNetCore.Mvc;

namespace YourProject.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult UploadBook()
        {
            return View();
        }
    }
}