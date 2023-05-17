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

        #region DefaultProductList
        /// <summary>
        /// A unit test to verify the default product list exists
        /// </summary>
        [Test]
        public void ProductList_Default_Should_Return_Content()
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
        #endregion DefaultProductList

        /// <summary>
        /// A unit test to test the ability to select a pet
        /// </summary>
        #region SelectProduct
        [Test]
        public void SelectProduct_Valid_ID_1_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var id = "SelectProduct(1)";

            var page = RenderComponent<ProductList>();

            // Find the buttons (more info)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the ID looking for, and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            // Act
            button.Click();

            // Get the markup to use for the assert statement
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("3"));
        }
        #endregion SelectProduct

    }
}
