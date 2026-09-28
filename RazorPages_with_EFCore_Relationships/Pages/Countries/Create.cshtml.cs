using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPages_with_EFCore_Relationships.Data;
using RazorPages_with_EFCore_Relationships.Models;

namespace RazorPages_with_EFCore_Relationships.Pages.Countries
{
    public class CreateModel : PageModel
    {
        private readonly RazorPages_with_EFCore_Relationships.Data.GeoDbContext _context;

        public CreateModel(RazorPages_with_EFCore_Relationships.Data.GeoDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ContinentChoose"] = new SelectList(_context.Continent, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Country Country { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //Variante 2: Wenn Continent nicht Nullable ist->Dann müssen wir es explizit von der Validierung herausnehmen

            //ModelState.Remove("Country.LanguagesInCountries");
            //ModelState.Remove("Country.Continet");



            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Country.Add(Country);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
