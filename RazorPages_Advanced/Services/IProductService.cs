using RazorPages_Advanced.Models;

namespace RazorPages_Advanced.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category);
    }
}
