using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages_with_EF_Relationships.Models;

namespace RazorPages_with_EF_Relationships.Pages.ContinentPages;

public class DeleteModel : PageModel
{
    private readonly GeoDbContext _context;

    public DeleteModel(GeoDbContext context)
    {
        _context = context;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var continent = await _context.Continents.FindAsync(id);
        if (continent != null)
        {
            Continent = continent;
            _context.Continents.Remove(Continent);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
