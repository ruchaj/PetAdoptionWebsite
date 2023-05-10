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
        #region TestSetup
        // New model for testing.
        public static ProductsController controllerModel;

        /// <summary>
        /// Initialize the tests herein.
        /// </summary>
        public void TestInitialize()
        {

        }
        #endregion TestSetup

        #region
        /// <summary>
        /// WIP.
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange
            // Act
            controllerModel.Get();

            // Assert
            Assert.AreEqual(true, controllerModel.ModelState.IsValid);

        }
        #endregion

        #region
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
        #endregion

        #region
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
        #endregion
    }
}
