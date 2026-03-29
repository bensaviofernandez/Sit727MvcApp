using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sit727MvcApp.Data;

namespace Sit727MvcApp.Controllers;

public class BooksController : Controller
{
    private readonly AppDbContext _context;

    public BooksController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var books = await _context.Books.ToListAsync();
        return View(books);
    }
}
