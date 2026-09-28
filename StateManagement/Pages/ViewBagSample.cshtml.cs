using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StateManagement.Pages
{
    public class ViewBagSampleModel : PageModel
    {
        public void OnGet()
        {
            ViewData.Add("Lottozahlen", "12-34-3-24-64534");
            ViewData.Add("Email", "kevinw@ppedv.de");
        }
    }
}
