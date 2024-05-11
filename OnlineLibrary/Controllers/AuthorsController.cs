using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.DataLayer.DBContext;
using OnlineLibrary.DataLayer.Entities;
using OnlineLibrary.Models;

namespace OnlineLibrary.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly OnlineLibraryDbContext _onlineLibraryDbContext;
        public AuthorsController(OnlineLibraryDbContext onlineLibraryDbContext)
        {
            _onlineLibraryDbContext = onlineLibraryDbContext;
        }
        public IActionResult Index()
        {
            var author = _onlineLibraryDbContext.Authors
                .Include(p => p.Books)
                .OrderBy(p => p.FullName);
            return View(author);
        }
        public IActionResult Details(int id)
        {
            var author = _onlineLibraryDbContext.Authors
                .Where(p => p.Id == id)
                .FirstOrDefault();
            return View(author);
        }

        public IActionResult Create()
        {
            var createAuthorViewModel = new AddAuthorModel();
            createAuthorViewModel.books = _onlineLibraryDbContext.Books.ToList();
            return View(createAuthorViewModel);
        }

        [HttpPost]
        public IActionResult Create([Bind("FullName, Description")] Author author)
        {
            if (ModelState.IsValid)
            {
                author.CreatedDate = DateTime.Now;
                _onlineLibraryDbContext.Authors.Add(author);
                _onlineLibraryDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return StatusCode(500, "Information is invalid");
            }
        }

        public IActionResult Update([FromRoute] int id)
        {
            var author = _onlineLibraryDbContext.Authors
                .Where(p => p.Id == id)
                .FirstOrDefault();
            return View(author);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete( int Id)
        {
            var author = await _onlineLibraryDbContext.Authors.FindAsync(Id);
            author.IsDelete = true;
            await _onlineLibraryDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Update([Bind("FullName, Description, Id")] Author author)
        {
            if (ModelState.IsValid)
            {
                //Check Author 

                author.UpdateDate = DateTime.Now;
                _onlineLibraryDbContext.Update(author);
                _onlineLibraryDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return StatusCode(500, "Information is invalid");
            }
        }
    }
}
