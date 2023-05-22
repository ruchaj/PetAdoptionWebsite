using System.Diagnostics;

using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Moq;

using ContosoCrafts.WebSite.Pages;
using ContosoCrafts.WebSite.Pages.Product;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace UnitTests.Pages.BlogAndStories
{
    /// <summary>
    /// A class to test the BlogAndStories.cshtml.cs page.
    /// </summary>
    public class BlogAndStoriesTests
    {
        #region TestSetup

        /// <summary>
        /// Page context for the Razor page.
        /// </summary>
        public static PageContext pageContext;

        /// <summary>
        /// Create a public page model for BlogAndStories.
        /// </summary>
        public static BlogAndStoriesModel pageModel;

        /// <summary>
        /// Test Message's getter setter works as expected.
        /// </summary>
        [Test]
        public void Test_validMessage_should_returnvalue()
        {
            // Arrange

            var expectedValue = "Test value";

            // Act
            pageModel.Message = expectedValue;

            // Assert
            Assert.AreEqual(expectedValue, pageModel.Message);
        }

        /// <summary>
        /// Set up the tests herein.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<BlogAndStoriesModel>>();

            pageModel = new BlogAndStoriesModel(TestHelper.ProductService)
            {
            };
        }
        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// Tests the OnGet method of the BlogAndStories page.
        /// </summary>
        [Test]
        public void OnGet_Valid_Activity_ShouldReturn_True()
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
