using MovieDatabase.Enums;

namespace MovieDatabase.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Genre MovieGenre { get; set; }
    }
}
