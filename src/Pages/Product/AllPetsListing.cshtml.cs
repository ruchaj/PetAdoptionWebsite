using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

// MT: This page will show all available pets.

namespace ContosoCrafts.WebSite.Pages.Product
{
    public class AllPetsListingModel : PageModel
    {
        private readonly ILogger<AllPetsListingModel> _logger;
        public JsonFileProductService PetService;
        public IEnumerable<ProductModel> Pets { get; private set; }

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
