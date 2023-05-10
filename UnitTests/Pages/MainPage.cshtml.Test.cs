using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Moq;
using ContosoCrafts.WebSite.Pages;
using System.Linq;
using Microsoft.Extensions.Logging;
using NUnit.Framework.Internal;
using System.Diagnostics;

namespace UnitTests.Pages.MainPage
{
    /// <summary>
    /// A class to test the MainPage (home page).
    /// </summary>
    public class JsonFileProductServiceTests
    {
        #region TestSetup
        /// <summary>
        /// Generate a new model for testing.
        /// </summary>
        public static IndexModel pageModel;

        /// <summary>
        /// Set up test.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<IndexModel>>();

            pageModel = new IndexModel(MockLoggerDirect, TestHelper.ProductService)
            {
                PageContext = TestHelper.PageContext,
                TempData = TestHelper.TempData,
            };
        }
        #endregion TestSetup

        /// <summary>
        /// Test OnGet to see if product returns.
        /// </summary>
        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange
            Activity activity = new Activity("activity");
            activity.Start();

            // Act
            pageModel.OnGet();

            // Reset
            activity.Stop();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.Products.ToList().Any());

        }

        #endregion OnGet
    }
}
