using System.Diagnostics;

using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Moq;

using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages.Privacy
{
    /// <summary>
    /// A class to test the Privacy.cshtml page.
    /// </summary>
    public class PrivacyTests
    {
        #region TestSetup
        public static PrivacyModel pageModel;

        /// <summary>
        /// Set up the tests herein.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<PrivacyModel >> ();

            pageModel = new PrivacyModel(MockLoggerDirect)
            {
                PageContext = TestHelper.PageContext,
                TempData = TestHelper.TempData,
            };
        }
        #endregion TestSetup

        #region OnGet
        [Test]
        public void OnGet_Valid_Activity_ShouldReturn_True()
        {
            // Arrange
            Activity activity = new Activity("activity");
            activity.Start();
        }
    }
}
