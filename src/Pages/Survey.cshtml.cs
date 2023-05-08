using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Drawing;

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
                                                " in your living space or do they need to be kept in " +
                                                "a cage or tank?";

        public string Question5 { get; set; } = "5. What is the reason behind your desire to have a pet?";


        public void OnGet()
        {
            //nothing to do here for now
        }

        public void OnPost()
        {
            var message = $"{Question1Answer}," +
                            $"{Question2Answer}," +
                            $"{Question3Answer}," +
                            $"{Question4Answer}," +
                            $"{Question5Answer}";

            

            string[] responses = message.Split(',');
            int point = GetPoint(responses);

            string result = null;

            if(point <= 30)
            {
                result = $"Your perfect pet can be a fish or a lot of fishes! They are cute and very easy to take care of";
            }
            else if (point <= 33)
            {
                result = $"Your perfect pet can be a small pet such as hamster, chinchillas! They are the best choice for beginners";
            }
            else if (point <= 74)
            {
                result = $"Your perfect pet can be a cat! They are calm and good companions";
            }
            else if (point <= 79)
            {
                result = $"Your perfect pet can be a small or medium dog! They are cute and fun to play with";
            }
            else if(point >= 80)
            {
                result = $"Your perfect pet can be a big dog! They are very protective and loyal! They are a great companion!";
            }

            ViewData["Message"] = result;

        
        }

        public int GetPoint(string[] responses)
        {
            int point = 0;
            for(int i =0; i < responses.Length; i++)
            {
                if (responses[i] == "smallfish")
                {
                    point += 1;
                }
                else if (responses[i] == "largefish")
                {
                    point += 2;
                }
                else if (responses[i] == "other")
                {
                    point += 3;
                }
                else if (responses[i] == "cat")
                {
                    point += 4;
                }
                else if (responses[i] == "smalldog")
                {
                    point += 5;
                }
                else if (responses[i] == "mediumdog")
                {
                    point += 6;
                }
                else if (responses[i] == "largedog")
                {
                    point += 7;
                }
            }

            return point;
        }
    }
}
