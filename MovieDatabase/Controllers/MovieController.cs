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
    }
}
