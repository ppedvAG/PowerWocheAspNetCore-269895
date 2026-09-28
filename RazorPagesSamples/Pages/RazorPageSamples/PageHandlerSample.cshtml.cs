using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesSamples.Pages.RazorPageSamples
{
    public class PageHandlerSampleModel : PageModel
    {
        public string MethodenEinstieg { get; set; }


        // https://localhost:7242/RazorPageSamples/PageHandlerSample
        public void OnGet()
        {
            MethodenEinstieg = "OnGet()";
        }


        //https://localhost:7189/RazorPageSamples/PageHandlerSample?handler=demo
        public void OnGetDemo()
        {
            MethodenEinstieg = "OnGetDemo()";
        }

        //https://localhost:7189/RazorPageSamples/PageHandlerSample?handler=DemoWithParam&parameter=yourValue
        public void OnGetDemoWithParam(string parameter)
        {
            MethodenEinstieg = "OnGetDemoWithParam(string parameter): " + parameter;
        }
    }
}
