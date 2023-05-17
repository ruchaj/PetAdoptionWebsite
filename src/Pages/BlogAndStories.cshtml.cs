using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using System.Collections.Generic;

namespace ContosoCrafts.WebSite.Pages
{
    public class BlogAndStoriesModel : PageModel
    {
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
        public void OnGet()
        {
            Pets = PetService.GetProductsWithStatus("adopted");
        }
    }
}
