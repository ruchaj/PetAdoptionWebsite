using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Product;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace UnitTests.Pages.Product.Read
{
    /// <summary>
    /// A class to test Read.
    /// </summary>
    public class ReadTests
    {
        #region TestSetup
        /// <summary>
        /// Generates a new model for testing.
        /// </summary>
        public static PetInformation pageModel;

        /// <summary>
        /// Initializes the tests herein.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new PetInformation(TestHelper.ProductService)
            {
            };
        }
        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// Testing the OnGet method.
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("1");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Playful,  Socialable, Curiosity", pageModel.Product.Description);
        }

        /// <summary>
        /// Test to check if OnPost properly updatesStatus and redirects
        /// </summary>
        [Test]
        public void OnPost_Should_Update_Status_And_Redirect_To_AllPetsListing()
        {
            // Arrange
            var id = "1";

            // Act
            var result = pageModel.OnPost(id);

            // Assert
            var redirectResult = (RedirectToPageResult)result;
            Assert.AreEqual("./AllPetsListing", redirectResult.PageName);

            var updatedProduct = TestHelper.ProductService.GetProducts().Where(p => p.Id == id).FirstOrDefault();
            Assert.NotNull(updatedProduct);
            Assert.AreEqual("adopted", updatedProduct.Status);
        }
        #endregion OnGet

    }
}