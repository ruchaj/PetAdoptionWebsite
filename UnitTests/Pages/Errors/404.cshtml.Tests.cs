using ContosoCrafts.WebSite.Pages;
using ContosoCrafts.WebSite.Pages.Errors;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Pages.Errors
{
    public class _404
    {
        #region OnGet
        /// <summary>
        /// A class to test OnGet function
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Valid_State()
        {
            // Arrange
            var model = new _404Model();

            // Act
            model.OnGet();

            // Assert
            Assert.AreEqual(true, model.ModelState.IsValid);
            
        }
        #endregion OnGet

    }
}
