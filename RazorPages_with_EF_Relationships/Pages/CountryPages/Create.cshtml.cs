using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages_with_EF_Relationships.Models;

namespace RazorPages_with_EF_Relationships.Pages.CountryPages;

public class CreateModel : PageModel
{
    private readonly GeoDbContext _context;

    public CreateModel(GeoDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Country Country { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Countries.Add(Country);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
