using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
namespace ContosoCrafts.WebSite.Pages
{
    public class IndexModel : PageModel
    {
        //Logs whenever the IndexModel is spawned
        private readonly ILogger<IndexModel> _logger;


        /// <summary>
        ///Adds a logger and a product service to every indexmodel instance
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public IndexModel(ILogger<IndexModel> logger,
            JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        /// <summary>
        /// Gets the product Service
        /// </summary>
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Gets all the products and sets them, but only in private/specific instances
        /// </summary>
        public IEnumerable<ProductModel> Products { get; private set; }

        /// <summary>
        /// Gets all the products in Index
        /// </summary>
        public void OnGet()
        {
            Products = ProductService.GetProducts();
        }
    }
}