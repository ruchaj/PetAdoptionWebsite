using System.Diagnostics;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;
using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages.AboutUs
{
    /// <summary>
    /// A class to test the AboutUs.cshtml.cs page.
    /// </summary>
    public class AboutUsTests
    {
        /// <summary>
        /// Generates a model for testing.
        /// </summary>
        #region TestSetup
        public static AboutUsModel pageModel;

        /// <summary>
        /// Set up the tests herein.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<AboutUsModel>>();

            pageModel = new AboutUsModel(MockLoggerDirect)
            {
                PageContext = TestHelper.PageContext,
                TempData = TestHelper.TempData,
            };
        }
        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// Tests the Onget method.
        /// </summary>
        [Test]
        public void OnGet_Valid_Activity_ShouldReturn_True()
        {
            // Arrange
            Activity activity = new Activity("activity");
            activity.Start();

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }
        #endregion OnGet
    }
}
