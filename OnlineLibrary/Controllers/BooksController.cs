using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.DataLayer.DBContext;
using OnlineLibrary.DataLayer.Entities;

namespace OnlineLibrary.Controllers
{
    public class BooksController : Controller
    {
        private readonly OnlineLibraryDbContext _onlineLibraryDbContext;
        public BooksController(OnlineLibraryDbContext onlineLibraryDbContext)
        {
            _onlineLibraryDbContext = onlineLibraryDbContext;
        }

        public IActionResult Index()
        {
          
                var books = _onlineLibraryDbContext.Books.OrderBy(p => p.Title);
                return View(books);    
        }
        public IActionResult Details(int id)
        {
            var books = _onlineLibraryDbContext.Books.Include(p => p.Author)
                .Where(p => p.Id == id)
                .FirstOrDefault();
            return View(books);
        }

    }
}
