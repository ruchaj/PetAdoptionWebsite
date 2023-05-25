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

        /// <summary>
        /// Defines Password for PetInformation 
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        ///Get the user's input for PetInformation 
        /// </summary>
        [BindProperty(Name = "password", SupportsGet = true)]
        public string UserInput { get; set; }


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
        public IActionResult OnGet(string id, string password)
        {
            //Take in product id
            Product = ProductService.GetProducts().FirstOrDefault(m => m.Id.Equals(id));
            if (Product == null && Password==null)
            {
                return RedirectToPage("/InvalidItem");
            }
            Password = password;
            Debug.WriteLine(id+ " "+Password);

            return Page();
        }


     

    }
}
