using ASPNETCORE_IOC_Container_Samples.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPNETCORE_IOC_Container_Samples.Pages
{
    public class MethodsInjectionSampleModel : PageModel
    {
        //Methoden Injection wird verwenden, wenn man einen Service explizit nur in einer Methode benötigt. 
        public void OnGet([FromServices] IGreeterService? greeterService)
        {
            string? greeting = greeterService?.GetGreeting();
            
            //...
        }
    }
}
