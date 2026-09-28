using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages_mit_EFCore_Scaffolder.Models;

namespace RazorPages_mit_EFCore_Scaffolder.Pages.MoviePages;

public class IndexModel : PageModel
{
    private readonly MovieDbContext _context;

    public IndexModel(MovieDbContext context)
    {
        _context = context;
    }

    public IList<Movie> Movie { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Movie = await _context.Movie.ToListAsync();
    }
}
