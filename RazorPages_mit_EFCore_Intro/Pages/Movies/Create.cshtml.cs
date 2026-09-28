using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages_mit_EFCore_Intro.Data;
using RazorPages_mit_EFCore_Intro.Models;

namespace RazorPages_mit_EFCore_Intro.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly MovieDbContext _context;

        public CreateModel(MovieDbContext context)
        {
            _context = context;
        }


        public IActionResult OnGet()
        {
            return Page(); //Explizite anfabe, dass wir die Page sehen
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;


        public async Task<IActionResult> OnPostAsync()
        {
            //Serverseitige Validierung 
            //ModelState ist eine Property aus PageModel


            //Könnten sogar Kombinationen abfrage
            if (Movie.Title == "The Crow")
            {
                ModelState.AddModelError("Title", "Der Film the Crow steht auf dem Index");
            }


            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            _context.Movies.Add(Movie);
            await _context.SaveChangesAsync();


            return RedirectToPage("./Index");
        }
    }
}
