using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesSamples.Pages.PartialViewSamples
{
    public class PartialViewSample4Model : PageModel
    {
        public List<string> Authors { get; set; }

        // Diese Methode wird aufgerufen, wenn die Seite geladen wird
        public void OnGet()
        {
            // Initialisierung der Autorenliste
            Authors = new List<string> { "Author 1", "Author 2", "Author 3" };
        }


        public IActionResult OnGetPartial() //Geht diese Methode mit einer Id
        {
            // Initialisierung der Autorenliste für die Partial View
            var authors = new List<string> { "Author 4", "Author 5", "Author 6" };

            // Debugging-Ausgabe
            Console.WriteLine("OnGetPartial aufgerufen");

            return new PartialViewResult
            {
                // Name der Partial View, die zurückgegeben wird
                ViewName = "_AuthorPartialRP",
                // ViewData wird an die Partial View übergeben
                ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<List<string>>(ViewData, authors)
            };
        }
    }
}
