using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages_with_EFCore_Relationships.Data;
using RazorPages_with_EFCore_Relationships.Models;

namespace RazorPages_with_EFCore_Relationships.Pages.Languages
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPages_with_EFCore_Relationships.Data.GeoDbContext _context;

        public DetailsModel(RazorPages_with_EFCore_Relationships.Data.GeoDbContext context)
        {
            _context = context;
        }

        public Language Language { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var language = await _context.Language.FirstOrDefaultAsync(m => m.Id == id);

            if (language is not null)
            {
                Language = language;

                return Page();
            }

            return NotFound();
        }
    }
}
