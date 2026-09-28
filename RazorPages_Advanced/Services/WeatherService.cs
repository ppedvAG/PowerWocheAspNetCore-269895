using RazorPages_Advanced.Models;

namespace RazorPages_Advanced.Services
{
    public class WeatherService : IWeatherService
    {
        public async Task<Weather> GetWeatherAsync(string city)
        {
            //Simulieren einen Request auf eine RestAPI
            await Task.Delay(1000);

            return new Weather
            {
                City = city,
                Temperature = Random.Shared.Next(-10, 35)
            };
        }
    }
}
