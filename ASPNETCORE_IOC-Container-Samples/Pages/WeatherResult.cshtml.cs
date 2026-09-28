using ASPNETCORE_IOC_Container_Samples.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPNETCORE_IOC_Container_Samples.Pages
{
    public class WeatherResultModel : PageModel
    {
        private readonly IWeatherService _weatherService;

        // Constructor Injection: ASP.NET Core stellt den registrierten
        // WeatherService automatisch über den Konstruktor bereit.
        public WeatherResultModel(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public string WeatherInfo { get; private set; } = string.Empty;

        public void OnGet()
        {
            // Das PageModel kennt nur den Servicevertrag über seine Methode.
            // Die Wetterregel und die Erzeugung der Temperatur bleiben im Service.
            WeatherInfo = _weatherService.GetWeatherInfo();
        }

    }
}
