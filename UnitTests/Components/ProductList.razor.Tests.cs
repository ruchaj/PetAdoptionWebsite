using Bunit;
using NUnit.Framework;
using ContosoCrafts.WebSite.Components;
using Microsoft.Extensions.DependencyInjection;
using ContosoCrafts.WebSite.Services;
using System.Linq;

namespace UnitTests.Components
{
    public class ProductListTests : BunitTestContext
    {
        #region TestSetup

        /// <summary>
        /// Initialize the tests herein
        /// </summary>
        [SetUp]
        public void TestInitialize() { }

        #endregion TestSetup

        #region FeaturedProductList
        /// <summary>
        /// A unit test to verify the featured product list exists
        /// </summary>
        [Test]
        public void ProductList_Featured_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act
            var page = RenderComponent<ProductList>();

            // Get the pets returned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains("Wolfie"));
        }
        #endregion FeaturedProductList

        #region SubmitRating
        [Test]
        public void SubmitRating_ValidID_ClickStarred_ShouldIncrementCount_AndCheckStar()
        {
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var id = "MoreInfoButton_1";

            var page = RenderComponent<ProductList>();

            var buttonList = page.FindAll("Button");

            var button = buttonList.First(m => m.OuterHtml.Contains(id));
            button.Click();

            var buttonMarkup = page.Markup;

            var starButtonList = page.FindAll("span");

            var preVoteCountSpan = starButtonList[1];
            var preVoteCountString = preVoteCountSpan.OuterHtml;

            Assert.AreEqual(true, preVoteCountString.Contains("3 Votes"));

        }
        #endregion SubmitRating

    }
}
