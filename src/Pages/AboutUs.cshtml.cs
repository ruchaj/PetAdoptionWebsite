using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    public class AboutUsModel : PageModel
    {
        /// <summary>
        /// Defines class with a logger that checks whenever it is accessed.
        /// </summary>
        private readonly ILogger<AboutUsModel> _logger;

        /// <summary>
        /// Constructor for the AboutUSModel.
        /// </summary>
        /// <param name="logger"></param>
        public AboutUsModel(ILogger<AboutUsModel> logger)
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
