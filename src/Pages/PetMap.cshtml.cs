using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoCrafts.WebSite.Services;
using ContosoCrafts.WebSite.Models;
using System.Collections.Generic;
using System.Linq;


namespace ContosoCrafts.WebSite.Pages
{
    public class PetMapModel : PageModel
    {
        //Data middle tier
        public JsonFileProductService PetService { get; }

        /// <summary>
        /// Creates a product model that specifies the Products as Pets
        /// </summary>
        public IEnumerable<ProductModel> Pets { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="petService"></param>
        public PetMapModel(JsonFileProductService petService)
        {
            PetService = petService;
        }
  

        /// <summary>
        /// Get request
        /// </summary>
        public void OnGet()
        {
            Pets = PetService.GetProductsWithStatus("available");
        }
    }
}
