using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Linq;

namespace ContosoCrafts.WebSite.Pages
{
    public class CustomerModel : PageModel
    {
        //Define what the final string for customer's information
        public string Message { get; set; }

        //read the customer's name from the cshtml file
        [BindProperty(Name = "Name", SupportsGet = true)]
        public string name { get; set; }

        //read the customer's phone number from the cshtml file
        [BindProperty(Name = "PhoneNumber", SupportsGet = true)]
        public string phone { get; set; }

        //read the customer's story from the cshtml file
        [BindProperty(Name = "SuccessStory", SupportsGet = true)]
        public string story { get; set; }

        //Read the choice of the customer from the cshtml file
        //if the checked box is clicked, they want to publish their information
        //if the checked box in not clicked, they dont want to publish their information
        [BindProperty(Name = "Display", SupportsGet = true)]
        public string isDisplay { get; set; }

        /// <summary>
        /// Defines PetService for CustomerModel 
        /// </summary>
        public JsonFileProductService PetService { get; }

        //model to initialize CustomerModel
        public CustomerModel(JsonFileProductService petService)
        {

            PetService = petService;
        }

        // Data
        public ProductModel Pet;
        /// <summary>
        /// Get request
        /// </summary>
        /// <param name="id"></param>
        public IActionResult OnGet(string id)
        {
            //Take in product id
            Pet = PetService.GetProducts().FirstOrDefault(m => m.Id.Equals(id));
            if (Pet == null)
            {
                return RedirectToPage("/InvalidItem");
            }
            return Page();
        }

        /// <summary>
        /// A class to handle the submit action
        /// </summary>
        public IActionResult OnPost(string id)
        {
            PetService.updateStatus(id);

            Message = $"{name}," + $"{phone}," + $"{story}," + $"{isDisplay}";

            
            PetService.updateCustomer(id, Message);

            return RedirectToPage("/BlogAndStories");
        }
    }
}
