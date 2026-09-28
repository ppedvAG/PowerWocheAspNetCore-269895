using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StateManagement.Pages
{
    public class ViewDataSampleModel : PageModel
    {
        public void OnGet()
        {
            ViewData.Add("Lottozahlen", Guid.NewGuid().ToString());
            ViewData.Add("EmailAdress", "Kevin.Winter.Freelance@gmail.com");
        }
    }
}
