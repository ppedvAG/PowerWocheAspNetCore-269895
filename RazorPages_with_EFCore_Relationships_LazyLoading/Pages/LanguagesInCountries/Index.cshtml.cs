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
    public class IndexModel : PageModel
    {
        private readonly RazorPages_with_EFCore_Relationships_LazyLoading.Data.GeoDbContext _context;

        public IndexModel(RazorPages_with_EFCore_Relationships_LazyLoading.Data.GeoDbContext context)
        {
            _context = context;
        }

        public IList<LanguageInCountry> LanguageInCountry { get;set; } = default!;

        public async Task OnGetAsync()
        {
            LanguageInCountry = await _context.LanguageInCountry.ToListAsync();
                
        }
    }
}
