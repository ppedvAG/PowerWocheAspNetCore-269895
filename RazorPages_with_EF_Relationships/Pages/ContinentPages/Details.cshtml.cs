using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages_with_EF_Relationships.Models;

namespace RazorPages_with_EF_Relationships.Pages.ContinentPages;

public class DetailsModel : PageModel
{
    private readonly GeoDbContext _context;
    public DetailsModel(GeoDbContext context)
    {
        _context = context;
    }

    public Continent Continent { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var continent = await _context.Continents.FirstOrDefaultAsync(m => m.Id == id);
        if (continent is null)
        {
            return NotFound();
        }
        else
        {
            Continent = continent;
        }

        return Page();
    }
}
