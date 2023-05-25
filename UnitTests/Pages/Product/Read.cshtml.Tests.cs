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


        /// <summary>
        /// Test userInput is as expected.
        /// </summary>
        [Test]
        public void Test_validPhone_should_returnvalue()
        {
            // Arrange

            var expectedValue = "Test value";

            // Act
            pageModel.UserInput = expectedValue;

            // Assert
            Assert.AreEqual(expectedValue, pageModel.UserInput);
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
            pageModel.OnGet("1","seattleu");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Playful,  Socialable, Curiosity", pageModel.Product.Description);
        }

        

        /// <summary>
        /// Testing the OnGet method with a valid product.
        /// </summary>
        [Test]
        public void OnGet_InValid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("", "");
            var result = (RedirectToPageResult)pageModel.OnGet("","");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("/InvalidItem", result.PageName);
        }
        #endregion OnGet

    }
}