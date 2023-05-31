using NUnit.Framework;
using ContosoCrafts.WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Models
{
    public class ProductTypeEnumTests
    {
        /// <summary>
        /// A class to test if the function return relevant producttype
        /// </summary>
        /// <param name="data"></param>
        /// <param name="expectedDisplayName"></param>
        [TestCase(ProductTypeEnum.Fish, "Small Freshwater, Large Saltwater")]
        [TestCase(ProductTypeEnum.Other, "Other Pets")]
        [TestCase(ProductTypeEnum.Cat, "Cats")]
        [TestCase(ProductTypeEnum.Dog, "Dogs")]
        [TestCase(ProductTypeEnum.Undefined, "")] // Test the default case

        public void DisplayName_ReturnsCorrectDisplayName(ProductTypeEnum data, string expectedDisplayName)
        {
            // Arrange

            // Act
            string actualDisplayName = data.DisplayName();

            // Assert
            Assert.AreEqual(expectedDisplayName, actualDisplayName);
        }
    }
}
