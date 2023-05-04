

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Read
{
    public class ReadTests
    {
        #region TestSetup
        public static PetInformation pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new PetInformation(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("1");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Playful,  Socialable, Curiosity", pageModel.Product.Description);
        }
        #endregion OnGet
    }
}