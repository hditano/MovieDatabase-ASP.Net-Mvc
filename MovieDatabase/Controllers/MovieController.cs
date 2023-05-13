using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Models;
using MovieDatabase.Services;

namespace MovieDatabase.Controllers
{
    public class MovieController : Controller
    {
        public MovieFakeDatabase _list;
        private MovieContext _context { get; set; }

        public MovieController(MovieContext context)
        {
            _list = new MovieFakeDatabase();
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_list.GetAllMovies());
        }
        [HttpGet]
        public IActionResult RandomMovie()
        {
            Random rand = new Random();

            Movie? movie = _list.GetAllMovies().FirstOrDefault(m => m.MovieId == rand.Next(1, 3));

            if (movie is null)
                return NotFound("Value not found");
            return View(movie);
        }

        [HttpGet]
        //public IActionResult SingleMovie(int id)
        //{
        //    var movie = _list.GetAllMovies().FirstOrDefault(m => m.MovieId == id);
            
        //    if (movie is null)
        //        return NotFound("Error");
        //    var myIdMovie = new Movie
        //    {
        //        Title = movie.Title,
        //        Description = movie.Description,
        //        MovieGenre = movie.MovieGenre
                
        //    };
        //    return View(myIdMovie);
        //}

        public IActionResult SingleMovie(int id)
        {
            var query = _context.Movies.Where(m => m.MovieId == id).FirstOrDefault();

            if (query is null)
                return NotFound();

            return View(query);
        }
    }
}
