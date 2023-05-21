using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Diagnostics;
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
        public IActionResult OnGet(string id)
        {
            //Take in product id
            Product = ProductService.GetProducts().FirstOrDefault(m => m.Id.Equals(id));
            if (Product == null)
            {
                return RedirectToPage("/InvalidItem");
            }

            return Page();
        }
        /// <summary>
        /// calls the Json file function onclick to update status
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult OnPost(string id)
        {
            //Take in product id
            ProductService.updateStatus(id);
            //redirects to listing without the current id
            return RedirectToPage("/Customer");
        }
    }
}
