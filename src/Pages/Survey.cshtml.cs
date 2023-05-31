using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace ContosoCrafts.WebSite.Pages
{
    public class SurveyModel : PageModel
    {
        

        //Define what the final result is after the users take the survey
        public string Message { get; set; }

        //read the answer for question 1 (checked radio) from the cshtml file
        [BindProperty(Name = "q1", SupportsGet = true)]
        public string Question1Answer { get; set; }

        //read the answer for question 2 (checked radio) from the cshtml file
        [BindProperty(Name = "q2", SupportsGet = true)]
        public string Question2Answer { get; set; }

        //read the answer for question 3 (checked radio) from the cshtml file
        [BindProperty(Name = "q3", SupportsGet = true)]
        public string Question3Answer { get; set; }

        //read the answer for question 4 (checked radio) from the cshtml file
        [BindProperty(Name = "q4", SupportsGet = true)]
        public string Question4Answer { get; set; }

        //read the answer for question 5 (checked radio) from the cshtml file
        [BindProperty(Name = "q5", SupportsGet = true)]
        public string Question5Answer { get; set; }


        //place holder for question 1
        public string Question1 { get; set; } = "1. In the event of unexpected expenses, " +
                                                "what is the maximum amount you are willing to" +
                                                " spend annually on your pet?";

        //place holder for question 2
        public string Question2 { get; set; } = "2. How much time are you willing to spend" +
                                                " cleaning up after your pets each day/week without " +
                                                "feeling frustrated?";

        //place holder for question 3
        public string Question3 { get; set; } = "3. How much time can you dedicate to spending with your" +
                                                " pets after a busy day?";

        //place holder for question 4
        public string Question4 { get; set; } = "4. Are you comfortable allowing your pet to roam free" +
                                                " in your living space or do they need to be kept in " +
                                                "a cage or tank?";

        //place holder for question 5
        public string Question5 { get; set; } = "5. What is the reason behind your desire to have a pet?";

        /// <summary>
        /// Defines PetService for AllPetsListingModel 
        /// </summary>
        public JsonFileProductService PetService { get; }


        /// <summary>
        /// Creates a product model that specifies the Products as Pets
        /// </summary>
        public IEnumerable<ProductModel> Pets { get; private set; }

   
        //model to initialize AllPetsListingModel
        public SurveyModel(JsonFileProductService petService)
        {

            PetService = petService;
        }

        /// <summary>
        /// A class to handle the OnGet()
        /// </summary>
        public IActionResult OnGet()
        {

            Pets = PetService.GetProductsWithStatus("adopted");

            return Page();
        }


        /// <summary>
        /// A class to handle the submit action
        /// </summary>
        public void OnPost()
        {
            //assign message value with the responses.
            var message = $"{Question1Answer}," +
                            $"{Question2Answer}," +
                            $"{Question3Answer}," +
                            $"{Question4Answer}," +
                            $"{Question5Answer}";

            
            //string array to store all the animals from the response
            string[] responses = message.Split(',');

            //define the point
            int point = GetPoint(responses);

            //initialize result as null value
            string result = null;
            string petType = null;

            //result is displayed based on point values.
            if(point<= 25)
            {
                result = $"Your perfect pet can be a fish or a lot of fishes! They are cute and very easy to take care of";
                petType = "fish";
            }
            else if (point <= 40)
            {
                result = $"Your perfect pet can be a small pet such as hamster, chinchillas! They are the best choice for beginners";
                petType = "other";
            }
            else if (point <= 74)
            {
                result = $"Your perfect pet can be a cat! They are calm and good companions";
                petType = "cat";
            }
            else if (point <= 79)
            {
                result = $"Your perfect pet can be a small or medium dog! They are cute and fun to play with";
                petType = "dog";
            }
            else if(point >= 80)
            {
                result = $"Your perfect pet can be a big dog! They are very protective and loyal! They are a great companion!";
                petType = "dog";
            }


            //assign Message with result
            Message = result;
            if (petType == "fish")
            {
                Pets = PetService.GetProductsWithProductType(ProductTypeEnum.Fish);
            }
            else if (petType == "other")
            {
                Pets = PetService.GetProductsWithProductType(ProductTypeEnum.Other);
            }
            else if (petType == "cat")
            {
                Pets = PetService.GetProductsWithProductType(ProductTypeEnum.Cat);
            }
            else if (petType == "dog")
            {
                Pets = PetService.GetProductsWithProductType(ProductTypeEnum.Dog);
            }
          




        }


        /// <summary>
        /// A class to count the final point.
        /// </summary>
        public int GetPoint(string[] responses)
        {
            //initilize points and set it to zero
            int point = 0;

            //run through the whole array and sum up the points
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

            //return the point value
            return point;
        }
    }
}
