using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages_RoutingSamples.Pages.Sample.FriendlyRouteSample
{
    public class SampleModel : PageModel
    {
        //https://localhost:7270/blog/sample?year=2022&month=4&day=12&title=abc???????????
        public void OnGet(int year, int month, int day, string title)
        {

        }
    }
}
