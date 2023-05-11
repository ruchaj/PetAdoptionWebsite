using System.Diagnostics;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;
using ContosoCrafts.WebSite.Pages;
using Microsoft.AspNetCore.Http;

namespace UnitTests.Pages.Error
{
    /// <summary>
    /// A class to test the Error.cshtml.cs page.
    /// </summary>
    public class ErrorTests
    {
        #region TestSetup
        public static ErrorModel pageModel;

        /// <summary>
        ///  Set up the tests herein.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<ErrorModel>>();

            pageModel = new ErrorModel(MockLoggerDirect)
            {
                PageContext = TestHelper.PageContext,
                TempData = TestHelper.TempData,
            };
        }
        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// Test that valid activity returns a request ID.
        /// </summary>
        [Test]
        public void OnGet_Valid_Activity_Set_ShouldReturn_RequestId()
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
            Assert.AreEqual(activity.Id, pageModel.RequestId);
        }

        /// <summary>
        /// Test that a non-null/empty request ID shows a request ID.
        /// </summary>
        [Test]
        public void ShowRequestId_RequestIdIsNotNullOrEmpty_ReturnsTrue()
        {
            // Arrange
            pageModel.RequestId = "123";

            // Act
            var result = pageModel.ShowRequestId;

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test that invalid activity returns a trace identifier.
        /// </summary>
        [Test]
        public void OnGet_InValid_Activity_Null_Should_Return_TraceIdentifier()
        {
            // Arrange

            // Act
            pageModel.OnGet();
            var httpContext = new DefaultHttpContext();
            httpContext.TraceIdentifier = "123";
            pageModel.PageContext.HttpContext = httpContext;
            Activity.Current = null;

            // Act
            pageModel.OnGet();

            // Reset

            // Assert
            Assert.AreEqual(httpContext.TraceIdentifier, pageModel.RequestId);
        }
        #endregion OnGet
    }
}
