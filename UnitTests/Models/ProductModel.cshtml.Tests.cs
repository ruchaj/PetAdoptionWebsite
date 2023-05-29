using NUnit.Framework;
using System.Text.Json;

namespace ContosoCrafts.WebSite.Models.Tests
{
    /// <summary>
    /// A class to test ProductModel.
    /// </summary>
    public class ProductModelTests
    {
        /// <summary>
        /// Set the properties for a test subject.
        /// </summary>
        [Test]
        public void ProductModel_SetsProperties()
        {
            // Arrange
            var product = new ProductModel
            {
                Id = "123",
                Name = "Fluffy",
                Age = "2 years",
                Breed = "Persian",
                Location = "New York",
                Description = "A fluffy cat",
                Cost = 50,
                Ratings = new int[] { 4, 5 },
            };

            // Act
            string json = product.ToString();
            var deserializedProduct = JsonSerializer.Deserialize<ProductModel>(json);
            product.InitializeLatAndLng();

            // Assert
            Assert.AreEqual("123", deserializedProduct.Id);
            Assert.AreEqual("Fluffy", deserializedProduct.Name);
            Assert.AreEqual("2 years", deserializedProduct.Age);
            Assert.Null(deserializedProduct.Image);
            Assert.AreEqual("Persian", deserializedProduct.Breed);
            Assert.AreEqual("New York", deserializedProduct.Location);
            Assert.AreEqual("A fluffy cat", deserializedProduct.Description);
            Assert.AreEqual(50, deserializedProduct.Cost);
            Assert.AreEqual(new int[] { 4, 5 }, deserializedProduct.Ratings);
            Assert.AreEqual("0.0", product.Lat); 
            Assert.AreEqual("0.0", product.Lng);
        }

        
    }
}
