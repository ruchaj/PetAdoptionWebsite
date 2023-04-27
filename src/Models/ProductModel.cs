using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    public class ProductModel
    {
        //attributes of a pet
        public string Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }

        [JsonPropertyName("img")]
        public string Image { get; set; }

        public string Breed { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Cost { get; set; }
        public int[] Ratings { get; set; }

        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);


    }
}