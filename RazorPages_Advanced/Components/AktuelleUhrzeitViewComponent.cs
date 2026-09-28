using Microsoft.AspNetCore.Mvc;

namespace RazorPages_Advanced.Components
{
    public class AktuelleUhrzeitViewComponent : ViewComponent
    {
        //KONVENTION!!! public IViewComponent Invoke()
        public IViewComponentResult Invoke()
        {
            DateTime currentDateTime = DateTime.Now;

            return View("Default", currentDateTime);
        }
    }
}
