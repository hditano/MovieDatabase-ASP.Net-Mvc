using Microsoft.AspNetCore.Mvc;
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
            var random = rand.Next(1, 5);
            var movie = _context.Movies.Where(m => m.MovieId == random).AsEnumerable();

            if (movie is null)
                return NotFound("Value not found");
            return View(movie);
        }

        [HttpGet]
        public IActionResult SingleMovie(int id)
        {
            var query = _context.Movies.Where(m => m.MovieId == id).FirstOrDefault();

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
