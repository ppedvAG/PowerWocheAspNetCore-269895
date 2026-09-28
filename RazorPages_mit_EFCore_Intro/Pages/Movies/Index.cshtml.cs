using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages_mit_EFCore_Intro.Data;
using RazorPages_mit_EFCore_Intro.Models;

namespace RazorPages_mit_EFCore_Intro.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly MovieDbContext _context;

        public IList<Movie> Movies { get; set; } = default!;

        public IndexModel(MovieDbContext context)
        {
            _context = context;
        }


        //OnGet - Asychrone Methde 
        public async Task OnGet()
        {
            Movies = await _context.Movies.ToListAsync();
        }
    }
}
