using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var transaction = await _context.Movies.FindAsync(id);
            return View("Edit", transaction);
        }

        [HttpPost, ActionName("ModifyMovie")]
        public async Task<IActionResult> Modify(Movie movie)
        {
            if (movie.MovieId == 0)
                return NotFound("Movie not foudn");
            else
                _context.Movies.Update(movie);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Admin");
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
