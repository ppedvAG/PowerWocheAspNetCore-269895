using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages_RoutingSamples.Pages
{
    public class PageDirectiveSample4Model : PageModel
    {
        //@page "{year}/{month}/{day}/{title}"
        public void OnGet(string year, string month, string day, string title)
        {
            //bitte verwendet debugger ;-)
        }
    }
}
