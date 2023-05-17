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
        [Test]
        public void SelectProduct_Valid_ID_1_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var id = "MoreInfoButton_1";
            var page = RenderComponent<ProductList>();

            // Find the Button (more info)
            var buttonList = page.FindAll("Button");

            // Find the pet that matches the ID looking for and click it
            var button = buttonList.First(m => m.Outer)
        }

    }
}
