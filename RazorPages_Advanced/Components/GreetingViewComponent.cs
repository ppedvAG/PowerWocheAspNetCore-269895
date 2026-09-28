using Microsoft.AspNetCore.Mvc;

namespace RazorPages_Advanced.Components
{
    public class GreetingViewComponent : ViewComponent
    {
        //Invoke
        public IViewComponentResult Invoke(string name)
        {
            string greeting = $"Hallo, {name}!";

            return View("Default", greeting);
        }
    }
}
