using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// MT: This page will show all available pets.

namespace ContosoCrafts.WebSite.Pages.Product
{
    public class AllPetsListingDevModeModel : PageModel
    {
        /// <summary>
        /// Defines Password for AllPetsListingModel 
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        ///Get the user's input for AllPetsListingModel 
        /// </summary>
        [BindProperty(Name = "password", SupportsGet = true)]
        public string UserInput { get; set; }

        /// <summary>
        /// Defines PetService for AllPetsListingModel 
        /// </summary>
        public JsonFileProductService PetService { get; }

        /// <summary>
        /// Creates a product model that specifies the Products as Pets
        /// </summary>
        public IEnumerable<ProductModel> Pets { get; private set; }

        //model to initialize AllPetsListingModel
        public AllPetsListingDevModeModel(JsonFileProductService petService)
        {

            PetService = petService;
        }

        //Gets all the pets in the allpets listing with the status available.
        public IActionResult OnGet(string password)
        {
            Password = password;
            Pets = PetService.GetProductsWithStatus("available");
            return Page();
        }

     

    }
}
