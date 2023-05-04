using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Makes sure the duration for storing the cache is 0, so it doesn't store
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        /// <summary>
        /// Definitions for getting an id and changing the id
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// defines showing the request id only if it isn't null/empty
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        //logger variable for when an errormodel is logged

        private readonly ILogger<ErrorModel> _logger;

        /// <summary>
        /// Constructs ErrorModel with logger
        /// </summary>
        /// <param name="logger"></param>
        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets the idea of the current activity that caused the error.
        /// </summary>
        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}