using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;

namespace RazorPagesMovie.Models;

public static class SeedDb
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesMovieContext>>()))
        {
            if (context == null || context.Movie == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB already seeded
            }

            // seed database with start values
            context.Movie.AddRange(
                new Movie
                {
                    Title = "Dune Part Two",
                    ReleaseDate = DateTime.Parse("17.03.2024"),
                    Genre = "Sci-Fi",
                    Director = "Denis Villeneuve",
                    Rating = "9/10"
                },

                new Movie
                {
                    Title = "Napoleon",
                    ReleaseDate = DateTime.Parse("15.02.2024"),
                    Genre = "History",
                    Director = "Ridley Scott",
                    Rating = "8/10"
                },

                new Movie
                {
                    Title = "Oppenheimer",
                    ReleaseDate = DateTime.Parse("31.07.2023"),
                    Genre = "Drama",
                    Director = "Christopher Nolan",
                    Rating = "8/10"
                },

                new Movie
                {
                    Title = "Jurassic Park",
                    ReleaseDate = DateTime.Parse("08.11.1999"),
                    Genre = "Action",
                    Director = "Steven Spielberg",
                    Rating = "10/10"
                },

                new Movie
                {
                    Title = "Across the Spiderverse",
                    ReleaseDate = DateTime.Parse("1.1.2023"),
                    Genre = "Animation",
                    Director = null,
                    Rating = "9/10"
                },


                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Director = "Rob Reiner",
                    Rating = "7/10"
                },

                new Movie
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Director = ""
                    //Rating = "7/10"
                },


                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Rating = "6/10"
                    
                }
            );
            context.SaveChanges();
        }
    }
}
