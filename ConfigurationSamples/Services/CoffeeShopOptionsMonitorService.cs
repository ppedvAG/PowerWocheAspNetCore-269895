using ConfigurationSamples.Configurations;
using Microsoft.Extensions.Options;

namespace ConfigurationSamples.Services
{
    public class CoffeeShopOptionsMonitorService : BackgroundService
    {
        private readonly IOptionsMonitor<CoffeeShopOptions> _optionsMonitor;
        private readonly CoffeeShopMonitorState _state;
        private readonly ILogger<CoffeeShopOptionsMonitorService> _logger;
        private IDisposable? _changeSubscription;

        public CoffeeShopOptionsMonitorService(
            IOptionsMonitor<CoffeeShopOptions> optionsMonitor,
            CoffeeShopMonitorState state,
            ILogger<CoffeeShopOptionsMonitorService> logger)
        {
            _optionsMonitor = optionsMonitor;
            _state = state;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // CurrentValue liefert den aktuell gültigen Optionsstand.
            _state.Update(
                _optionsMonitor.CurrentValue,
                "Initialer Wert aus IOptionsMonitor.CurrentValue.");

            // OnChange wird ausgelöst, wenn eine Konfigurationsquelle einen neuen
            // Wert meldet. Der Callback läuft unabhängig von Razor Pages.
            _changeSubscription = _optionsMonitor.OnChange((options, name) =>
            {
                string optionsName = string.IsNullOrWhiteSpace(name) ? "Standard" : name;
                string message = $"Änderung erkannt für Optionsname: {optionsName}.";

                _state.Update(options, message);
                _logger.LogInformation(
                    "Coffee-Shop-Konfiguration geändert: {ShopName}",
                    options.Name);
            });

            try
            {
                // Ein BackgroundService muss aktiv laufen. Die eigentliche Arbeit
                // erledigt hier OnChange; die Wartephase hält den Service am Leben.
                while (!stoppingToken.IsCancellationRequested)
                {
                    await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
                }
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            {
                // Eine Cancellation beim Herunterfahren ist ein normaler Ablauf.
            }
        }

        public override void Dispose()
        {
            // Die Registrierung muss entfernt werden, damit kein Callback auf den
            // bereits beendeten Service zeigt.
            _changeSubscription?.Dispose();
            base.Dispose();
        }
    }

}
