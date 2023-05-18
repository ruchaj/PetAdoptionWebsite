using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages.Product.Update
{
    /// <summary>
    /// A class to test Update.
    /// </summary>
    public class UpdateTests
    {
        #region TestSetup
        public static UpdateModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new UpdateModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// Testing the OnGet method.
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("1","Create");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Wolfie", pageModel.Product.Name);
            Assert.AreEqual("Create", pageModel.titlePage);
        }
        #endregion OnGet

        #region OnPost
        /// <summary>
        /// Testing a valid call to the OnPost method.
        /// </summary>
        [Test]
        public void OnPost_Valid_Should_Return_Products()
        {
            // Arrange
            pageModel.Product = new ProductModel
            {
                Id = "10",
                Name = "title",
                Description = "description",
                Age = "age",
                Breed = "breed",
                Image = "image",
                Cost = "cost",
                Location= "location"
            };

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("AllPetsListing"));
        }

        /// <summary>
        /// Testing an invalid call to the OnPost method.
        /// </summary>
        [Test]
        public void OnPost_InValid_Model_NotValid_Return_Page()
        {
            // Arrange

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }
        #endregion OnPost
    }
}