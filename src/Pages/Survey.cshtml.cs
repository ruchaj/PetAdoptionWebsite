using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages
{
    public class SurveyModel : PageModel
    {
        [BindProperty(Name = "q1", SupportsGet = true)]
        public string Question1Answer { get; set; }

        [BindProperty(Name = "q2", SupportsGet = true)]
        public string Question2Answer { get; set; }

        [BindProperty(Name = "q3", SupportsGet = true)]
        public string Question3Answer { get; set; }

        [BindProperty(Name = "q4", SupportsGet = true)]
        public string Question4Answer { get; set; }

        [BindProperty(Name = "q5", SupportsGet = true)]
        public string Question5Answer { get; set; }


        public string Question1 { get; set; } = "1. In the event of unexpected expenses, " +
                                                "what is the maximum amount you are willing to" +
                                                " spend annually on your pet?";

        public string Question2 { get; set; } = "2. How much time are you willing to spend" +
                                                " cleaning up after your pets each day/week without" +
                                                "feeling frustrated?";

        public string Question3 { get; set; } = "3. How much time can you dedicate to spending with your" +
                                                " pets after a busy day?";

        public string Question4 { get; set; } = "4. Are you comfortable allowing your pet to roam free" +
                                                " in your living space or do they need to be kept in" +
                                                "a cage or tank?";

        public string Question5 { get; set; } = "5. What is the reason behind your desire to have a pet?";


        public void OnGet()
        {
            //nothing to do here for now
        }

        public void OnPost()
        {
            var message = $"You selected {Question1Answer} for question 1, " +
                            $"and {Question2Answer} for question2, " +
                            $"and {Question3Answer} for question3, " +
                            $"and {Question4Answer} for question4, " +
                            $"and {Question5Answer} for question5, ";

            ViewData["Message"] = message;

            
        }
    }
}
