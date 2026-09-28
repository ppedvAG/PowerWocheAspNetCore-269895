using RazorPages_Advanced.Models;

namespace RazorPages_Advanced.Services;

public interface IWeatherService
{
    Task<Weather> GetWeatherAsync(string city);
}
