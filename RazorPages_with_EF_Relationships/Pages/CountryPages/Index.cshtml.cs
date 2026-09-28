using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages_with_EF_Relationships.Models;

namespace RazorPages_with_EF_Relationships.Pages.CountryPages;

public class IndexModel : PageModel
{
    private readonly GeoDbContext _context;

    public IndexModel(GeoDbContext context)
    {
        _context = context;
    }

    public IList<Country> Country { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Country = await _context.Countries.ToListAsync();
    }
}
