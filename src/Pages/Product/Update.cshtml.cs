using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;


namespace ContosoCrafts.WebSite.Pages
{
    public class UpdateModel : PageModel
    {

        // Data middletier
        public JsonFileProductService ProductService { get; }

        public string titlePage { get; set; }
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="productService"></param>
        public UpdateModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // The data to show, bind to it for the post
        [BindProperty]
        public ProductModel Product { get; set; }

        /// <summary>
        /// Load data
        /// </summary>
        /// <param name="id"></param>
        public IActionResult OnGet(string id, string titlepage)
        {
            Product = ProductService.GetProducts().FirstOrDefault(m => m.Id.Equals(id));
            if (Product == null)
            {
                return RedirectToPage("/InvalidItem");
            }

            titlePage = titlepage;
            return Page();
        }

        /// <summary>
        /// Post the model back to the page
        /// Update data, then return to the pet listing page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            //Check if state is valid
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Call update data function
            ProductService.UpdateData(Product);

            //Return to pet listing page
            return RedirectToPage("./AllPetsListing");
        }
    }
}
