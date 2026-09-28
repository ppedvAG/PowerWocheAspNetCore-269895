using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages_with_EFCore_Relationships_LazyLoading.Data;
using RazorPages_with_EFCore_Relationships_LazyLoading.Models;

namespace RazorPages_with_EFCore_Relationships_LazyLoading.Pages.LanguagesInCountries
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPages_with_EFCore_Relationships_LazyLoading.Data.GeoDbContext _context;

        public DeleteModel(RazorPages_with_EFCore_Relationships_LazyLoading.Data.GeoDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LanguageInCountry LanguageInCountry { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var languageincountry = await _context.LanguageInCountry.FirstOrDefaultAsync(m => m.Id == id);

            if (languageincountry is not null)
            {
                LanguageInCountry = languageincountry;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var languageincountry = await _context.LanguageInCountry.FindAsync(id);
            if (languageincountry != null)
            {
                LanguageInCountry = languageincountry;
                _context.LanguageInCountry.Remove(LanguageInCountry);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
