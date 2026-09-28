using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesSamples.Pages.RazorPageSamples
{
    public class QueryStringSampleModel : PageModel
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }


        //https://localhost:7189/RazorPageSamples/QueryStringSample?name=Otto&year=2025&month=2
        public void OnGet(string name, int year, int month)
        {
            Name = name;
            Year = year;
            Month = month;
        }
    }
}
