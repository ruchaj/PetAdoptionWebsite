using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    public class InvalidItemModel : PageModel
    {
        /// <summary>
        /// Defines class with a logger that checks whenever it is accessed.
        /// </summary>
        private readonly ILogger<AboutUsModel> _logger;

        /// <summary>
        /// Constructor for the InvalidItemModel.
        /// </summary>
        /// <param name="logger"></param>
        public InvalidItemModel(ILogger<AboutUsModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get method.
        /// </summary>
        public void OnGet()
        {
        }
    }
}
