using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Models;
using MovieDatabase.Services;

namespace MovieDatabase.Controllers
{
    public class MovieController : Controller
    {
        public MovieFakeDatabase _list;

        public MovieController()
        {
            _list = new MovieFakeDatabase();
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
        public IActionResult SingleMovie(int id)
        {
            var movie = _list.GetAllMovies().FirstOrDefault(m => m.MovieId == id);
            
            if (movie is null)
                return NotFound("Error");
            var myIdMovie = new Movie
            {
                Title = movie.Title,
                Description = movie.Description,
                MovieGenre = movie.MovieGenre
                
            };
            return View(myIdMovie);
        }
    }
}
