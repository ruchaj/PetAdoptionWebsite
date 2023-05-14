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
        [StringLength(60, MinimumLength = 1)]
        public string Name { get; set; }

        //Defines the age of a pet
        [Required]
        [StringLength(25, MinimumLength = 1)]
        public string Age { get; set; }

        //Gets the JsonPropertyName image that can be uploaded for a pet, and defines the image
        [JsonPropertyName("img")]
        public string Image { get; set; }

        //Defines the Breed of the pet
        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string Breed { get; set; }

        //Defines the Location of the pet, which can be filtered for
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Location { get; set; }

        //Defines the description of each pet
        [Required]
        [StringLength(1000, MinimumLength = 2)]
        public string Description { get; set; }

        //Defines how much each pet costs
        [Required]
        [StringLength(1000000, MinimumLength = 1)]
        public string Cost { get; set; }

        //Defines the ratings array, which will dynamically change with the ratings added to the website
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(5)]
        public int[] Ratings { get; set; }

        //Defines the category of the pets such as dogs, cat, fishes or other smaller pets. 
        [StringLength(60, MinimumLength = 1)]
        public string Category { get; set; }

        //Defines the status "available/adopted" of the pets.
        public string Status { get; set; }

        /// <summary>
        /// Overrides any default to turn the information into a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);


    }
}