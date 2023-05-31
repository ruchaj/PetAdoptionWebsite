using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Product
{
    public class CreateModel : PageModel
    {
        // Data middle tier
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="productService"></param>
        public CreateModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // The data to show.
        public ProductModel Product;

        /// <summary>
        /// A class to handle OnGet() .
        /// </summary>
        public IActionResult OnGet()
        {
            Product = ProductService.CreateData();
            return RedirectToPage("./Update", new { Id = Product.Id, titlepage = "Create" });
        }
    }
}
