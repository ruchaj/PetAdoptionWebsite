﻿using System.Diagnostics;

using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Moq;

using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages.BlogAndStories
{
    /// <summary>
    /// A class to test the BlogAndStories.cshtml.cs page.
    /// </summary>
    public class BlogAndStoriesTests
    {
        /// <summary>
        /// Create a public page model for BlogAndStories.
        /// </summary>
        #region TestSetup
        public static BlogAndStoriesModel pageModel;

        /// <summary>
        /// Set up the tests herein.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<BlogAndStoriesModel>>();

            pageModel = new BlogAndStoriesModel(MockLoggerDirect)
            {
                PageContext = TestHelper.PageContext,
                TempData = TestHelper.TempData,
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