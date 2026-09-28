using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages_RoutingSamples.Pages
{
    public class PageDirectiveSample1Model : PageModel
    {
        public string Title { get; private set; }

        public void OnGet(string title)
        {
            // Assign the title parameter to the Title property
            Title = title;
        }
    }
}
