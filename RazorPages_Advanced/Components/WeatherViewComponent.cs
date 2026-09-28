using Microsoft.AspNetCore.Mvc;
using RazorPages_Advanced.Models;
using RazorPages_Advanced.Services;

namespace RazorPages_Advanced.Components
{
    public class WeatherViewComponent : ViewComponent
    {
        private IWeatherService _weatherService;

        public WeatherViewComponent(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string city)
        {
            Weather weather = await _weatherService.GetWeatherAsync(city);

            return View("Default", weather);
        }
    }
}
