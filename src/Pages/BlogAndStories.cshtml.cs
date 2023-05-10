using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages
{
    public class BlogAndStoriesModel : PageModel
    {
        /// <summary>
        /// Defines class with a logger that checks whenever it is accessed.
        /// </summary>
        private readonly ILogger<BlogAndStoriesModel> _logger;

        /// <summary>
        ///  Constructor for the BlogAndStoriesModel.
        /// </summary>
        /// <param name="logger"></param>
        public BlogAndStoriesModel(ILogger<BlogAndStoriesModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets stories of successful pet adoptions.
        /// </summary>
        public void OnGet()
        {
        }
    }
}
