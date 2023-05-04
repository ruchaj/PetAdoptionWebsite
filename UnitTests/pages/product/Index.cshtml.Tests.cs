using System.Linq;



using Microsoft.AspNetCore.Mvc.RazorPages;



using NUnit.Framework;



using ContosoCrafts.WebSite.Pages.Product;



namespace UnitTests.Pages.Product.Index
{
    public class IndexTests
    {
        #region TestSetup
        public static PageContext pageContext; //page context for the Razor page



        public static AllPetsListingModel pageModel; //generates a new model of AllPetsListingModel to test



        [SetUp]

        //Initializes pageModel to include TestHelper.ProductService
        public void TestInitialize()
        {
            pageModel = new AllPetsListingModel(TestHelper.ProductService)
            {
            };
        }



        #endregion TestSetup


        //Tests onGet, checking if State is valid and that the page returns a list of pets
        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange



            // Act
            pageModel.OnGet();



            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.Pets.ToList().Any());
        }
        #endregion OnGet
    }
}