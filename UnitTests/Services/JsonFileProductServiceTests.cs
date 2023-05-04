using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;
using System.Linq;
namespace UnitTests.Pages.Product.AddRating
{
    public class JsonFileProductServiceTests
    {
        #region TestSetup

        [SetUp]
        public void TestInitialize()
        {
        }
        #endregion TestSetup

        #region AddRating
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

        #region GetFeaturedProdect
        #endregion GetFeaturedProduct

        #region Update
        #endregion Update

        #region Delete
        #endregion Delete

        #region Create
        #endregion Create

    }
}
