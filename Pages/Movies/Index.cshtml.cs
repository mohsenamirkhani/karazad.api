using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using razorPage.Data;
using razorPage.Models;

namespace razorPage.Pages_Movies
{
    public class IndexModel : PageModel
    {
        private readonly razorPage.Data.AppDbContext _context;

        public IndexModel(razorPage.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            var genreuery = from m in _context.Movie
                            orderby m.Genre
                            select m.Genre;

            var movie = from m in _context.Movie select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movie = movie.Where(m => m.Title.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movie = movie.Where(m => m.Genre == MovieGenre);
            }
            Genres = new SelectList(await genreuery.Distinct().ToListAsync());
            Movie = await movie.ToListAsync();
        }
    }
}
