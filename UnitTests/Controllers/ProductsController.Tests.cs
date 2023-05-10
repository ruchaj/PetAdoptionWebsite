using NUnit.Framework;
using System.Linq;
using ContosoCrafts.WebSite.Controllers;

namespace UnitTests.Controllers
{
    /// <summary>
    /// A class to test the ProductsController.cs page.
    /// </summary>
    public class ProductsControllerTests
    {
        #region TestSetup
        /// <summary>
        /// Initialize the tests herein.
        /// </summary>
        public void TestInitialize()
        {

        }
        #endregion TestSetup

        #region
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
    }
}
