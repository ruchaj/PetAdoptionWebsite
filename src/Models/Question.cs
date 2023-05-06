using System.Collections.Generic;
using System.Text.Json;

namespace ContosoCrafts.WebSite.Models
{
    public class Question
    {
       
        public string Text { get; set; }
        public List<string> Choices { get; set; }
        public override string ToString() => JsonSerializer.Serialize<Question>(this);
    }
}
