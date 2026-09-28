using ConfigurationSamples.Configurations;

namespace ConfigurationSamples.Services
{
    /// <summary>
    /// Enthält den zuletzt vom Background Service beobachteten Optionsstand.
    /// Der Status wird von einem Hintergrundthread geschrieben und von Razor Pages
    /// gelesen; deshalb werden Zugriffe mit lock geschützt.
    /// </summary>
    public class CoffeeShopMonitorState
    {
        private readonly object _syncRoot = new();
        private string _shopName = "Noch keine Messung";
        private int _tableCount;
        private DateTimeOffset? _lastChangedUtc;
        private string _message = "Der Background Service wurde noch nicht initialisiert.";

        public string ShopName
        {
            get { lock (_syncRoot) return _shopName; }
        }

        public int TableCount
        {
            get { lock (_syncRoot) return _tableCount; }
        }

        public DateTimeOffset? LastChangedUtc
        {
            get { lock (_syncRoot) return _lastChangedUtc; }
        }

        public string Message
        {
            get { lock (_syncRoot) return _message; }
        }

        public void Update(CoffeeShopOptions options, string message)
        {
            lock (_syncRoot)
            {
                _shopName = options.Name;
                _tableCount = options.DefaultTableCount;
                _lastChangedUtc = DateTimeOffset.UtcNow;
                _message = message;
            }
        }
    }

}
