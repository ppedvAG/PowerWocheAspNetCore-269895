using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages_with_EF_Relationships.Models;

namespace RazorPages_with_EF_Relationships.Pages.ContinentPages;

public class EditModel : PageModel
{
    private readonly GeoDbContext _context;

    public EditModel(GeoDbContext context)
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
        Continent = continent;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Continent).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ContinentExists(Continent.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool ContinentExists(int id)
    {
        return _context.Continents.Any(e => e.Id == id);
    }
}
