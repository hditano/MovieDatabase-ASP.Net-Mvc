using MovieDatabase.Models;

namespace MovieDatabase.Services
{
    public interface IMovieService
    {
        public List<Movie> GetAllMovies(); 
    }
}
