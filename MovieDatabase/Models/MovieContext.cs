using Microsoft.EntityFrameworkCore;

namespace MovieDatabase.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData
              (
                 new Movie
                 {
                     MovieId = 1,
                     Title = "Duro de Matar",
                     Description = "Pelicula de accion",
                     MovieGenre = Enums.Genre.Action
                 },

                new Movie
                {
                    MovieId = 2,
                    Title = "Lalita",
                    Description = "Sosito",
                    MovieGenre = Enums.Genre.ForAllFamily
                }
             );
        }
    }
}
