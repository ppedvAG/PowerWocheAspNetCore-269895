using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPages_with_EFCore_Relationships.Data;
using RazorPages_with_EFCore_Relationships.Models;

namespace RazorPages_with_EFCore_Relationships.Pages.LanguagesInCountries
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
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Name");
            ViewData["LanguageId"] = new SelectList(_context.Language, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public LanguageInCountry LanguageInCountry { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            //languagePercentSum der bisher vergebene Sprachen in einem Land
            int languagePercentSum = _context.LanguageInCountry.Where(c => c.CountryId == LanguageInCountry.CountryId).Sum(c => c.Percent);

            if (languagePercentSum + LanguageInCountry.Percent > 100)
            {
                ModelState.AddModelError("LanguageInCountry.Percent", $"Es kann höchsten noch {100 - languagePercentSum} % vergeben werden");
            }


            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.LanguageInCountry.Add(LanguageInCountry);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
