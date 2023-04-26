using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Pet information page
    /// </summary>
    public class Index1Model : PageModel
    {
        //Data middle tier
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productService"></param>
        public Index1Model(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // Data
        public ProductModel Product;

        /// <summary>
        /// Get request
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string id)
        {
            //Take in product id
            Product = ProductService.GetProducts().FirstOrDefault(m => m.Id.Equals(id));
        }
    }
}
