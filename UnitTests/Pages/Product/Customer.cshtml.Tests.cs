using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages.Product
{
    public class Customer
    {
        #region TestSetup
        /// <summary>
        /// Page context for the Razor page.
        /// </summary>
        public static PageContext pageContext;

        /// <summary>
        /// Generates a new model to test.
        /// </summary>
        public static CustomerModel pageModel;

        /// <summary>
        /// Initializes pageModel to include TestHelper.ProductService.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new CustomerModel(TestHelper.ProductService)
            {
            };
        }

        /// <summary>
        /// Test name's output is as expected.
        /// </summary>
        [Test]
        public void Test_validName_should_returnvalue()
        {
            // Arrange
            
            var expectedValue = "Test value";

            // Act
            pageModel.name = expectedValue;

            // Assert
            Assert.AreEqual(expectedValue, pageModel.name);
        }

        /// <summary>
        /// Test phone's output is as expected.
        /// </summary>
        [Test]
        public void Test_validPhone_should_returnvalue()
        {
            // Arrange
     
            var expectedValue = "Test value";

            // Act
            pageModel.phone = expectedValue;

            // Assert
            Assert.AreEqual(expectedValue, pageModel.phone);
        }

        /// <summary>
        /// Test story's output is as expected.
        /// </summary>
        [Test]
        public void Test_validStory_should_returnvalue()
        {
            // Arrange
       
            var expectedValue = "Test value";

            // Act
            pageModel.story = expectedValue;

            // Assert
            Assert.AreEqual(expectedValue, pageModel.story);
        }

        /// <summary>
        /// Test isDisplay's output is as expected.
        /// </summary>
        [Test]
        public void Test_validDisplay_should_returnvalue()
        {
            // Arrange
            
            var expectedValue = "Test value";

            // Act
            pageModel.isDisplay = expectedValue;

            // Assert
            Assert.AreEqual(expectedValue, pageModel.isDisplay);
        }

        /// <summary>
        /// Test Message's getter setter works as expected.
        /// </summary>
        [Test]
        public void Test_validMessage_should_returnvalue()
        {
            // Arrange

            var expectedValue = "Test value";

            // Act
            pageModel.Message = expectedValue;

            // Assert
            Assert.AreEqual(expectedValue, pageModel.Message);
        }



        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// Testing the OnGet method with a valid product.
        /// </summary>
        [Test]
        public void OnGet_InValid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("");
            var result = (RedirectToPageResult)pageModel.OnGet("");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("/InvalidItem", result.PageName);
        }


        /// <summary>
        /// Testing the OnGet method and return page.
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Current_Page()
        {
            // Arrange

            // Act
            pageModel.OnGet("1");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            
        }

        #endregion OnGet


        #region OnPost
        /// <summary>
        /// Testing the OnPost method with a valid product.
        /// </summary>
        [Test]
        public void OnPost_Valid_Should_Return_ProductAfterUpdated()
        {
            // Arrange
            var id = "1";

            // Act
            var result = pageModel.OnPost(id);

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            var updatedProduct = TestHelper.ProductService.GetProducts().Where(p => p.Id == id).FirstOrDefault();
            Assert.NotNull(updatedProduct);
            Assert.AreEqual("adopted", updatedProduct.Status);
        }
        #endregion OnPost


    }
}

