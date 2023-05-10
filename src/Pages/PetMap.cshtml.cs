using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages
{
    public class PetMapModel : PageModel
    {
        /// <summary>
        /// Defines class with a logger that checks whenever it is accessed.
        /// </summary>
        private readonly ILogger<PetMapModel> _logger;

        /// <summary>
        /// Constructor for the PetMapModel.
        /// </summary>
        /// <param name="logger"></param>
        public PetMapModel(ILogger<PetMapModel> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Gets the map of pets/pet adoption centers in the area specified.
        /// </summary>
        public void OnGet()
        {
        }
    }
}
