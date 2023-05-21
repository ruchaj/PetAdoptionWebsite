using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

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

        public void OnGet()
        {
            //nothing to do here by now
        }

        /// <summary>
        /// A class to handle the submit action
        /// </summary>
        public IActionResult OnPost()
        {
            //if the checkbox is clicked, read the information of the customer.
            if ($"{isDisplay}" == "on")
            {
                Message = $"{name}, " + $"{phone}, " + $"{story}, " + $"{isDisplay}, ";
            }
            
            Debug.WriteLine(Message);

            return RedirectToPage("/BlogAndStories");
        }
    }
}
