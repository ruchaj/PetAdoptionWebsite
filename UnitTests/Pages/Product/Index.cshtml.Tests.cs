using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Index
{
    /// <summary>
    /// A class to test the Index page, which is the home page for our website.
    /// </summary>
    public class IndexTests
    {
        #region TestSetup
        /// <summary>
        /// Page context for the Razor page.
        /// </summary>
        public static PageContext pageContext;

        /// <summary>
        /// Generates a new model to test.
        /// </summary>
        public static AllPetsListingModel pageModel;

        /// <summary>
        /// Initializes pageModel to include TestHelper.ProductService.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new AllPetsListingModel(TestHelper.ProductService)
            {
            };
        }



        #endregion TestSetup


        //Tests onGet, checking if State is valid and that the page returns a list of pets
        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange



            // Act
            pageModel.OnGet();



            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.Pets.ToList().Any());
        }
        #endregion OnGet
    }
}