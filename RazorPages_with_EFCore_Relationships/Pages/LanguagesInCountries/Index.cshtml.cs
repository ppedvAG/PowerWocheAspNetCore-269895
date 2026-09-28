using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages_with_EFCore_Relationships.Data;
using RazorPages_with_EFCore_Relationships.Models;

namespace RazorPages_with_EFCore_Relationships.Pages.LanguagesInCountries
{
    public class IndexModel : PageModel
    {
        private readonly RazorPages_with_EFCore_Relationships.Data.GeoDbContext _context;

        public IndexModel(RazorPages_with_EFCore_Relationships.Data.GeoDbContext context)
        {
            _context = context;
        }

        public IList<LanguageInCountry> LanguageInCountry { get;set; } = default!;

        public async Task OnGetAsync()
        {
            LanguageInCountry = await _context.LanguageInCountry
                .Include(l => l.Country)
                .Include(l => l.Language).ToListAsync();
        }
    }
}
