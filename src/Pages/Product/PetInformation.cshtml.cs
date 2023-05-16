using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    /// Pet information page
    /// </summary>
    public class PetInformation : PageModel
    {
        //Data middle tier
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productService"></param>
        public PetInformation(JsonFileProductService productService)
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

        /// <summary>
        /// Changes status to adopted on click.
        /// </summary>
        /// <param name="id"></param>
        public void OnPost(string id)
        {
            Product = ProductService.GetProducts().FirstOrDefault(m => m.Id.Equals(id));
            Product.Status = "adopted";
        }

    }
}
