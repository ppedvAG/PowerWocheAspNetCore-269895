namespace ConfigurationSamples.Configurations
{
    public class CoffeeShopOptions
    {
        public const string SectionName = "CoffeeShop";

        public string Name { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;

        public int DefaultTableCount { get; set; }
        public CoffeeShopFeatures Features { get; set; } = new();
    }

    public class CoffeeShopFeatures
    {
        public bool OffersDelivery { get; set; }
        public bool OffersVeganMilk { get; set; }
    }
}
