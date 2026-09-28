using ConfigurationSamples.Configurations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace ConfigurationSamples.Pages
{
    public class OptionSnapshotDemoModel : PageModel
    {
        //private readonly IOptionsSnapshot<CoffeeShopOptions> _coffeeShopOptionsSnapshot;
        public CoffeeShopOptions Shop { get; private set; } = new();

        public OptionSnapshotDemoModel(IOptionsSnapshot<CoffeeShopOptions> coffeeShopOptionsSnapshot)
        {
            Shop = coffeeShopOptionsSnapshot.Value;
        }

        public void OnGet()
        {
            
        }
    }
}
