using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesSamples.Pages.RazorPageSamples
{
    public class AspPageHandlerSample2Model : PageModel
    {
        public int Ergebnis { get; set; } = 0;

       


        public void OnGet()
        {
            Ergebnis = 0;
        }

        public void OnPostAdd()
        {
            int a, b = 0;
            //Request.Form ist eine grundlege Funktionalität (Alternative Variante) um ein Formular auszuwerten.
            int.TryParse(Request.Form["eins"], out a);
            int.TryParse(Request.Form["zwei"], out b);
            Ergebnis = a + b;
        }

        public void OnPostSub()
        {
            int a, b = 0;
            int.TryParse(Request.Form["eins"].FirstOrDefault(), out a);
            int.TryParse(Request.Form["zwei"].FirstOrDefault(), out b);
            Ergebnis = a - b;
        }
    }
}
