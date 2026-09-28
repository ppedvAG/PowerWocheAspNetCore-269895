using ASPNETCORE_IOC_Container_Samples.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPNETCORE_IOC_Container_Samples.Pages
{
    public class GreeterSamplePageModel : PageModel
    {
        private readonly IGreeterService? _greeterService;


        public string Greeting { get; set; }

        public GreeterSamplePageModel(IGreeterService? greeterService)
        {
            _greeterService = greeterService;
        }

        public void OnGet()
        {
            Greeting = _greeterService?.GetGreeting();
        }
    }
}
