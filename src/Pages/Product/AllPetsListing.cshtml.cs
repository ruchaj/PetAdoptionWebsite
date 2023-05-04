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
    public class AllPetsListingModel : PageModel
    {
        private readonly ILogger<AllPetsListingModel> _logger;
        public JsonFileProductService PetService { get; }
        public IEnumerable<ProductModel> Pets { get; private set; }

        //model to initialize AllPetSlISTINGmODEL
        public AllPetsListingModel(JsonFileProductService petService)
        {

                PetService = petService;
        }

        public AllPetsListingModel(ILogger<AllPetsListingModel> logger,
            JsonFileProductService petService)
        {
            _logger = logger;
            PetService = petService;
        }
        public void OnGet()
        {
            Pets = PetService.GetProducts();
        }

    }
}
