using Microsoft.AspNetCore.Mvc;
using RazorPages_Advanced.Services;

namespace RazorPages_Advanced.Components
{
    public class ProductListViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public ProductListViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string category)
        {
            var products = await _productService.GetProductsByCategoryAsync(category);

            //Funktioniert mit ViewData/ViewBag, TempData? Zusätzlich Infos für die UI
            ViewBag.Category = category;   
            
            return View("Default", products);
           
        }
    }
}
