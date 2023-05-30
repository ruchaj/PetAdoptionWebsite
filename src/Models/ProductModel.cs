using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    public class ProductModel
    {
        /// <summary>
        /// attributes of a pet
        /// </summary>
        /// 
        //Defines the id assigned to a pet
        public string Id { get; set; }

        //Defines the name given to a pet
        [Required]
        [StringLength(maximumLength: 33, MinimumLength = 1, ErrorMessage = "The Title should have a length of more than {2} and less than {1}")]
        public string Name { get; set; }

        //Defines the age of a pet
      
        public string Age { get; set; }

        //Gets the JsonPropertyName image that can be uploaded for a pet, and defines the image
        [JsonPropertyName("img")]
        public string Image { get; set; }

        //Defines the Breed of the pet
    
        public string Breed { get; set; }

        //Defines the Location of the pet, which can be filtered for
  
        public string Location { get; set; }

        //Defines the description of each pet
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 1, ErrorMessage = "The Description should have a length of more than {2} and less than {1}")]
        public string Description { get; set; }

        //Defines how much each pet costs
        public float Cost { get; set; }

        //Defines the ratings array, which will dynamically change with the ratings added to the website
        
        public int[] Ratings { get; set; }

        //Defines the category of the pets such as dogs, cat, fishes or other smaller pets. 
        public ProductTypeEnum ProductType { get; set; } = ProductTypeEnum.Undefined;

      

        //Defines the status "available/adopted" of the pets.
        public string Status { get; set; }

        //Defines the comments of the pets.
        public List<CommentModel> Comments { get; set; } = new List<CommentModel>();

        //Defines the customerinfo if applicable
        public string Customer { get; set; }

        //Defines latitude
        public string Lat { get; set; }

        //Defines longitude
        public string Lng { get; set; }

        /// <summary>
        /// Overrides any default to turn the information into a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);

        // Initializes the Lat and Lng as 0.0 if null
        public void InitializeLatAndLng()
        {
            Lat ??= "0.0";
            Lng ??= "0.0";
        }

    }
}