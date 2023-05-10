using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    public class PrivacyModel : PageModel
    {

        /// <summary>
        /// defines class with a logger that checks whenever its accessed.
        /// </summary>
        private readonly ILogger<PrivacyModel> _logger;

        /// <summary>
        /// Constructor for the PrivacyModel.
        /// </summary>
        /// <param name="logger"></param>
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets the privacy statement
        /// </summary>

        public void OnGet()
        {
        }
    }
}
