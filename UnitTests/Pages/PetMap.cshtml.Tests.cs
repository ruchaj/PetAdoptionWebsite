using System.Diagnostics;

using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Moq;

using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages.PetMap
{
    /// <summary>
    /// A class to test the PetMap.cshtml.cs page.
    /// </summary>
    public class PetMapTests
    {
        #region TestSetup
        /// <summary>
        /// Create a public page model for PetMap.
        /// </summary>
        public static PetMapModel pageModel;

        /// <summary>
        /// Set up the tests herein.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<PetMapModel>>();

            pageModel = new PetMapModel(MockLoggerDirect)
            {
                PageContext = TestHelper.PageContext,
                TempData = TestHelper.TempData,
            };

        }
        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// Tests the OnGetmethod of the PetMap page.
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
