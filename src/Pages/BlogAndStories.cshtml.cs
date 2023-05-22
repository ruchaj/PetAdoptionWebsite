using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ContosoCrafts.WebSite.Pages
{
    public class BlogAndStoriesModel : PageModel
    {

        public string Message { get; set; }
        /// <summary>
        /// Defines PetService for AllPetsListingModel 
        /// </summary>
        public JsonFileProductService PetService { get; }

        /// <summary>
        /// Creates a product model that specifies the Products as Pets
        /// </summary>
        public IEnumerable<ProductModel> Pets { get; private set; }

        //model to initialize AllPetsListingModel
        public BlogAndStoriesModel(JsonFileProductService petService)
        {

            PetService = petService;
        }

        //Gets all the pets in the allpets listing with the status adopted.
        /// <summary>
        /// Load data
        /// </summary>
        /// <param name="message"></param>
        public IActionResult OnGet()
        {
            Pets = PetService.GetProductsWithStatus("adopted");

            return Page();
        }


     
       
    }
}
