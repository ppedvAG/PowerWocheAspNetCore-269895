using ASPNETCORE_IOC_Container_Samples.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPNETCORE_IOC_Container_Samples.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IGuidService _guidService;


        //Public Variable für die Ausgabe in der Index.cshtml
        public string GuidString = string.Empty;

        public IndexModel(IGuidService guidService)
        {
            _guidService = guidService;
        }

        public void OnGet()
        {
            GuidString = _guidService.GetGuidString(); 
        }
    }
}
