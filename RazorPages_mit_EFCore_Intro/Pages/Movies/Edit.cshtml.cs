using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages_mit_EFCore_Intro.Data;
using RazorPages_mit_EFCore_Intro.Models;

namespace RazorPages_mit_EFCore_Intro.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly MovieDbContext _context;

        public EditModel(MovieDbContext context)
        {
            _context = context;
        }


        [BindProperty]
        public Movie Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            //Wurde eine ID übergeben
            if (id == null)
            {
                return NotFound(); //404
            }


            Movie? movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }


            Movie = movie;
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Wir markieren, dass der Datensatz von Movie (editierbar) sich geändert hat. 
            _context.Attach(Movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!MovieExists(Movie.Id))
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

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(m => m.Id == id);
        }
    }
}
