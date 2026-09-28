using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesSamples.Pages.RazorPageSamples
{
    public class AspPageHandlerSampleModel : PageModel
    {
        public int Ergebnis { get; set; }

        public void OnGet()
        {
            Ergebnis = 0;
        }


        public void OnPost()
        {
            int a, b = 0;

            //Request.Form ist eine grundlege Funktionalität (Alternative Variante) um ein Formular auszuwerten.
            int.TryParse(Request.Form["eins"], out a);
            int.TryParse(Request.Form["zwei"], out b);
            Ergebnis = a + b;
        }

    }
}
