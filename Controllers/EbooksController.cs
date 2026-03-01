using Microsoft.AspNetCore.Mvc;

public class EbooksController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult EbookDetails()
    {
        return View();
    }

    public IActionResult UploadPdf()
    {
        return View();
    }
}