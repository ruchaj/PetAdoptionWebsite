using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Pages.Product.Index
{
    /// <summary>
    /// A class to test the Index page, which is the home page for our website.
    /// </summary>
    public class IndexDevTests
    {
        #region TestSetup
        /// <summary>
        /// Page context for the Razor page.
        /// </summary>
        public static PageContext pageContext;

        /// <summary>
        /// Generates a new model to test.
        /// </summary>
        public static AllPetsListingDevModeModel pageModel;

        /// <summary>
        /// Initializes pageModel to include TestHelper.ProductService.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new AllPetsListingDevModeModel(TestHelper.ProductService)
            {
            };
        }

        /// <summary>
        /// Test password's output is as expected.
        /// </summary>
        [Test]
        public void Test_validName_should_returnvalue()
        {
            // Arrange

            var expectedValue = "Test value";

            // Act
            pageModel.Password = expectedValue;

            // Assert
            Assert.AreEqual(expectedValue, pageModel.Password);
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


        //Tests onGet, checking if State is valid and that the page returns a list of pets
        #region OnGet
        /// <summary>
        /// A class to test if OnGet() function return Product if a valid password passed
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange



            // Act
            pageModel.OnGet("seattleu");



            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.Pets.ToList().Any());
        }
        #endregion OnGet

        
    }
}