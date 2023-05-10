using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    public class ContactModel : PageModel
    {

        /// <summary>
        /// defines class with a logger that checks whenever its accessed.
        /// </summary>
        private readonly ILogger<ContactModel> _logger;

        public ContactModel(ILogger<ContactModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets the Contact information
        /// </summary>
        public void OnGet()
        {
        }
    }
}
