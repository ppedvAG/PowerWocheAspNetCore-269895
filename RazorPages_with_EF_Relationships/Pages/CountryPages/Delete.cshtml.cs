using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages_with_EF_Relationships.Models;

namespace RazorPages_with_EF_Relationships.Pages.CountryPages;

public class DeleteModel : PageModel
{
    private readonly GeoDbContext _context;

    public DeleteModel(GeoDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Country Country { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var country = await _context.Countries.FirstOrDefaultAsync(m => m.Id == id);
        if (country is null)
        {
            return NotFound();
        }
        else
        {
            Country = country;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var country = await _context.Countries.FindAsync(id);
        if (country != null)
        {
            Country = country;
            _context.Countries.Remove(Country);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
