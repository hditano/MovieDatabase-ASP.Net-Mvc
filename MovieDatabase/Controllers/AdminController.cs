using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Models;

namespace MovieDatabase.Controllers
{
    public class AdminController : Controller
    {
        private MovieContext _context { get; set; }

        public AdminController(MovieContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var movie = _context.Movies.ToList();
            return View(movie);
        }

        [HttpGet, ActionName("Modify")]
        public async Task<IActionResult> ModifyMovie(int id)
        {
            Console.WriteLine("Hello");
            var transaction = await _context.Movies.FindAsync(id);
            return View("Edit", transaction);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var transaction = await _context.Movies.FindAsync(id);
            if (transaction != null)
            {
                _context.Movies.Remove(transaction);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
