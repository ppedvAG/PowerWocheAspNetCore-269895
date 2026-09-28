using RazorPages_Advanced.Models;

namespace RazorPages_Advanced.Services
{
    public class ProductService : IProductService
    {
        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category)
        {
            // Simulierte Daten für das Beispiel
            await Task.Delay(1000); // Simuliert eine asynchrone Operation
            return new List<Product>
            {
                new Product { Name = "Produkt 1", Price = 10 },
                new Product { Name = "Produkt 2", Price = 20 }
            };
        }
    }
}
