using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    /// Manage the Delete of the data for a single record
    /// </summary>
    public class DeleteModel : PageModel
    {
        // Data middletier
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public DeleteModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // The data to show, bind to it for the post
        [BindProperty]
        public ProductModel Product { get; set; }

        /// <summary>
        /// REST Get request
        /// Loads the Data
        /// </summary>
        /// <param name="id"></param>
        public IActionResult OnGet(string id)
        {
            //The product is selected based on the given Id
            Product = ProductService.GetProducts().FirstOrDefault(m => m.Id.Equals(id));
            if (Product == null)
            {
                return RedirectToPage("/InvalidItem");
            }

            return Page();
        }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable Product
        /// Call the data layer to Delete that data
        /// Then return to the index page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            //If the state is not valid, it will return to the previous page!
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //The delete function is being called to delete the product with the passed ProductId
            ProductService.DeleteData(Product.Id);

            //After the pet successfully deleted, return to allpetslisting page
            return RedirectToPage("./AllPetsListing");
        }
    }
}