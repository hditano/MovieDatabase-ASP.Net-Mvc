using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Models;
using MovieDatabase.Services;

namespace MovieDatabase.Controllers
{
    public class MovieController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            MovieFakeDatabase list = new MovieFakeDatabase();
            var mylist = list.GetAllMovies();
            return View(mylist);
        }
        [HttpGet]
        public IActionResult RandomMovie()
        {
            Random rand = new Random();
            MovieFakeDatabase list = new MovieFakeDatabase();
            var mylist = list.GetAllMovies();
            Movie? movie = mylist.FirstOrDefault(m => m.MovieId == rand.Next(1, 2));
            if (movie is null)
                return NotFound();
            return View(movie);
        }
    }
}
