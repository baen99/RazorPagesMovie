using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        /* Dependency: the class IndexModel has the attribute/property _context
           which is instance of another class (RazorPagesMovieContext) */
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        // Dependency Injection: Constructor assigns instance of corresponding class to dependng class 
        public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            // project out only distinct genres to filter by
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());

            // query syntax
            var movies = from m in _context.Movie
                         select m;

            // if there is a search String only return matching entries
            if (!string.IsNullOrEmpty(SearchString))
            {
                // method syntax
                // s is of type movies
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }

            Movie = await movies.ToListAsync();
        }
    }
}
