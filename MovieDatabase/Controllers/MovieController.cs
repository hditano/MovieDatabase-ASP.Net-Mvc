using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Models;
using MovieDatabase.Services;
using System.Diagnostics.Eventing.Reader;

namespace MovieDatabase.Controllers
{
    public class MovieController : Controller
    {
        private MovieContext _context { get; set; }

        public MovieController(MovieContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Movies.ToList());
        }
        [HttpGet]
        public IActionResult RandomMovie()
        {
            Random rand = new Random();
            var random = rand.Next(1, _context.Movies.Count());
            Console.WriteLine(random);
            var movie = _context.Movies.Where(m => m.MovieId == random).AsAsyncEnumerable();

            if (movie is null)
                return NotFound("Value not found");
            return View(movie);
        }

        [HttpGet]
        public async Task<IActionResult> SingleMovie(int id)
        {
            var query = await _context.Movies.Where(m => m.MovieId == id).FirstOrDefaultAsync();

            if (query is null)
                return NotFound();

            return View(query);
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
