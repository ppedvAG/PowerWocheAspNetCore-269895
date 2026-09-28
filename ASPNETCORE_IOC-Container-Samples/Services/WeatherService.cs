namespace ASPNETCORE_IOC_Container_Samples.Services;

/// <summary>
/// Liefert eine einfache, zufällig erzeugte Wetterinformation.
/// </summary>
public class WeatherService : IWeatherService
{
    private static readonly string[] WeatherConditions =
    [
        "regnet",
        "sonnig",
        "schneit",
        "bewölkt"
    ];

    /// <summary>
    /// Erzeugt den Wetterzustand und eine dazu passende Temperatur.
    /// </summary>
    public string GetWeatherInfo()
    {
        string condition = WeatherConditions[Random.Shared.Next(WeatherConditions.Length)];
        int temperature = GetTemperature(condition);

        return $"Das Wetter: {condition}, Temperatur: {temperature} °C";
    }

    private int GetTemperature(string condition)
    {
        return condition switch
        {
            // Next(untere Grenze, obere Grenze) schließt die obere Grenze aus.
            // Daher liefert Next(-5, 3) Werte von -5 bis 2: immer unter 3 °C.
            "schneit" => Random.Shared.Next(-5, 3),
            "regnet" => Random.Shared.Next(6, 17),
            "sonnig" => Random.Shared.Next(18, 32),
            "bewölkt" => Random.Shared.Next(7, 20),
            _ => 10
        };
    }
}
