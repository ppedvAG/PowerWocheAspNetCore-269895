using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConfigurationSamples.Pages
{
    public class ConfigurationSamplePageModel : PageModel
    {
        private readonly IConfiguration _configuration;


        public string ShopName { get; private set; } = string.Empty;
        public string Currency { get; private set; } = string.Empty;
        public int TableCount { get; private set; } = 0;
        public bool OffersVeganMilk { get; private set; } = false;
        public string MissingValue { get; private set; } = string.Empty;


        public ConfigurationSamplePageModel(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public void OnGet()
        {
            ShopName = _configuration["CoffeeShop:Name"] ?? "Default Shop Name";
            Currency = _configuration["CoffeeShop:Currency"] ?? "USD";
            TableCount = int.TryParse(_configuration["CoffeeShop:DefaultTableCount"], out var tableCount) ? tableCount : 0;
            OffersVeganMilk = bool.TryParse(_configuration["CoffeeShop:Features:OffersVeganMilk"], out var offersVeganMilk) ? offersVeganMilk : false;



            // Ein nicht vorhandener Schlüssel liefert null. Deshalb ist ein
            // Fallback sinnvoll, wenn die Einstellung optional ist.
            MissingValue = _configuration["CoffeeShop:DoesNotExist"] ?? "Fallback: nicht gesetzt";
        }
    }
}
