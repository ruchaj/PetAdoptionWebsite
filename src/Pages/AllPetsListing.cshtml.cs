using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ContosoCrafts.WebSite.Pages
{
    public class AllPetsListingModel : PageModel
    {
        private readonly ILogger<AllPetsListingModel> _logger;
        public JsonFileProductService PetService;

        public AllPetsListingModel(ILogger<AllPetsListingModel> logger,
            JsonFileProductService petService)
        {
            _logger = logger;
        }
    }
}
