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
        public string Description { get; set; }

        //Defines how much each pet costs
        public string Cost { get; set; }

        //Defines the ratings array, which will dynamically change with the ratings added to the website
        public int[] Ratings { get; set; }

        /// <summary>
        /// Overrides any default to turn the information into a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);


    }
}