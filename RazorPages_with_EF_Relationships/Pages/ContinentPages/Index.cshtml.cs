using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages_with_EF_Relationships.Models;

namespace RazorPages_with_EF_Relationships.Pages.ContinentPages;

public class IndexModel : PageModel
{
    private readonly GeoDbContext _context;

    public IndexModel(GeoDbContext context)
    {
        _context = context;
    }

    public IList<Continent> Continent { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Continent = await _context.Continents.ToListAsync();
    }
}
