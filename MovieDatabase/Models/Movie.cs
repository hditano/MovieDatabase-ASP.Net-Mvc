using System.ComponentModel.DataAnnotations;
using MovieDatabase.Enums;

namespace MovieDatabase.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        [Required(ErrorMessage = "Please enter a Title")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Please enter a Description ")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Please enter a Genre")]
        public Genre MovieGenre { get; set; }
    }
}
