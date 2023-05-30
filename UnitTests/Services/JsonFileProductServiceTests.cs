using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Moq;
using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;
using System.Linq;
using ContosoCrafts.WebSite.Services;

namespace UnitTests.Pages.Product.AddRating
{
    /// <summary>
    /// A class to test the JsonFileProductService.
    /// </summary>
    public class JsonFileProductServiceTests
    {
        #region TestSetup
        /// <summary>
        /// Initializing the tests herein.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }
        #endregion TestSetup

        #region AddRating
        /// <summary>
        ///  Testing adding a rating to an invalid product.
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Null_Should_Return_False()
        {
            // Arrange

            // Act
            //Test null and invalid product id
            var result = TestHelper.ProductService.AddRating(null, 1);
            var result2 = TestHelper.ProductService.AddRating("dsafdg", 1);


            // Assert
            Assert.AreEqual(false, result);
            Assert.AreEqual(false, result2);
        }

        /// <summary>
        /// Testing an invalid rating.
        /// </summary>
        [Test]
        public void AddRating_InValid_()
        {
            // Arrange
            var data = TestHelper.ProductService.GetProducts().First();

            // Act
            //Test above and below rating range
            var result = TestHelper.ProductService.AddRating("1", 7);
            var result2 = TestHelper.ProductService.AddRating(data.Id, -1);

            // Assert
            Assert.AreEqual(false, result);
            Assert.AreEqual(false, result2);
        }

        /// <summary>
        /// Testing a valid rating for a valid product.
        /// </summary>
        [Test]
        public void AddRating_Valid_Product_Valid_Rating_Valid_Should_Return_True()
        {
            // Arrange

            // Get the First data item
            var data = TestHelper.ProductService.GetProducts().First();
            var countOriginal = data.Ratings.Length;

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, 5);
            var dataNewList = TestHelper.ProductService.GetProducts().First();
            var result1 = TestHelper.ProductService.AddRating("3", 1);


            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());
            Assert.AreEqual(true, result1);
        }
        #endregion AddRating

        #region FeaturedProducts
        /// <summary>
        /// Testing a call to GetFeaturedProducts, which should return four products.
        /// </summary>
        /*[Test]
        public void GetFeaturedProducts_ReturnsFourProducts()
        {

            // Act
            var featuredProducts = TestHelper.ProductService.GetFeaturedProducts();

            // Assert
            Assert.AreEqual(4, featuredProducts.Count());
        }*/
        #endregion FeaturedProducts
        #region Status
        /// <summary>
        /// Testing a call to updateStatus, which should update status.
        /// </summary>
        [Test]
        public void UpdateStatus_Should_Update_Product_Status_To_Adopted()
        {
            // Arrange
            var productId = "1";

            // Act
            TestHelper.ProductService.updateStatus(productId);

            // Assert
            var product = TestHelper.ProductService.GetProducts().Where(p => p.Id == productId).FirstOrDefault();
            Assert.NotNull(product);
            Assert.AreEqual("adopted", product.Status);
        }
        #endregion Status

        #region PetType
        /// <summary>
        /// Testing a call to updateStatus, which should update status.
        /// </summary>
        [Test]
        public void ReturnProductType_Should_Return_Given__ProductType()
        {
            // Arrange
        

            // Act
            var products = TestHelper.ProductService.GetProductsWithProductType(ProductTypeEnum.Dog);

            // Assert
            Assert.NotNull(products);
            Assert.AreEqual(ProductTypeEnum.Dog, products.FirstOrDefault().ProductType);
        }
        #endregion PetType
    }
}
