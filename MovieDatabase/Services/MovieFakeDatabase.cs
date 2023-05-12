using MovieDatabase.Models;

namespace MovieDatabase.Services
{
    public class MovieFakeDatabase
    {
        public List<Movie> GetAllMovies()
        {
            var item1 = new Movie
            {
                MovieId = 1,
                Title = "Duro de Matar",
                Description = "Pelicula de accion",
                MovieGenre = Enums.Genre.Action
            };

            var item2 = new Movie
            {
                MovieId = 2,
                Title = "Lalita",
                Description = "Sosito",
                MovieGenre = Enums.Genre.ForAllFamily
            };

            return new List<Movie> { item1, item2 };
        }
    }
}
