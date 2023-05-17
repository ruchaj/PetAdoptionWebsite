using System.Diagnostics;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;
using ContosoCrafts.WebSite.Pages;
using ContosoCrafts.WebSite.Pages.Product;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace UnitTests.Pages.PetMap
{
    /// <summary>
    /// A class to test the PetMap.cshtml.cs page.
    /// </summary>
    public class PetMapModelTests
    {
        /// <summary>
        /// Page model for testing.
        /// </summary>
        public static PetMapModel pageModel;

        /// <summary>
        /// Initializes pageModel.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new PetMapModel(TestHelper.ProductService);
        }

        // Tests OnGet, checking if State is valid and that the page returns a list of pets.
        [Test]
        public void OnGet_Valid_Should_Return_Pets()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Assert
            Assert.IsTrue(pageModel.ModelState.IsValid);
            Assert.IsTrue(pageModel.Pets.ToList().Any());
        }
    }
}
