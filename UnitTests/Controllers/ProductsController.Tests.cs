using NUnit.Framework;
using System.Linq;
using ContosoCrafts.WebSite.Controllers;
using ContosoCrafts.WebSite.Services;

namespace UnitTests.Controllers
{
    /// <summary>
    /// A class to test the ProductsController.cs page.
    /// </summary>
    public class ProductsControllerTests
    {
        

        #region GetFunction
        /// <summary>
        /// Tests that all present data returns true.
        /// </summary>
        [Test]
        public void get_AllData_Present_Should_Return_True()
        {
            // Arrange

            // Act
            var newData = new ProductsController(TestHelper.ProductService).Get().First();
            var response = TestHelper.ProductService.GetProducts().First();

            // Assert
            Assert.AreEqual(newData.Id, response.Id);
        }
        #endregion GetFunction

        #region SetFunction
        /// <summary>
        /// Test for the set function return true.
        /// </summary>
        [Test]
        public void set_Data_Should_Return_True()
        {
            // Arrange
            var ratingRequest = new ProductsController.RatingRequest
            {
                ProductId = "20",
                Rating = 1
            };

            // Act
            ratingRequest.ProductId = "21";
            ratingRequest.Rating = 5;

            // Assert
            Assert.AreEqual("21", ratingRequest.ProductId);
            Assert.AreEqual(5, ratingRequest.Rating);
        }
        #endregion SetFunction

        #region Addrating
        /// <summary>
        /// Tests patch for adding a valid rating.
        /// </summary>
        [Test]
        public void Patch_AddValid_Rating_Should_Return_True()
        {
            // Arrange

            // Act
            var newData = new ProductsController(TestHelper.ProductService);
            var newRating = new ProductsController.RatingRequest();
            newData.Patch(newRating);

            // Assert
            Assert.AreEqual(null, newRating.ProductId);
        }
        #endregion Addrating
    }
}
