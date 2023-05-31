using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace UnitTests.Pages.Survey
{
    
    /// <summary>
    /// A class to test the Survey page.
    /// </summary>
    public class Survey
    {
        #region TestSetup

        /// <summary>
        /// Page context for the Razor page.
        /// </summary>
        public static PageContext pageContext;

        /// <summary>
        /// Create a public page model for BlogAndStories.
        /// </summary>
        public static SurveyModel pageModel;

      

        /// <summary>
        /// Set up the tests herein.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<SurveyModel>>();

            pageModel = new SurveyModel(TestHelper.ProductService)
            {
            };
        }
        #endregion TestSetup
        /// <summary>
        /// Test the GetPoint method.
        /// </summary>
        [Test]
        public void GetPoint_ReturnsCorrectPoint()
        {
            // Arrange
            
            var responses = new[] { "smallfish", "largefish", "cat", "smalldog", "other", "mediumdog", "largedog" };

            // Act
            var point = pageModel.GetPoint(responses);

            // Assert
            Assert.AreEqual(28, point);
        }


        #region OnGet
        /// <summary>
        /// Test the OnGet method.
        /// </summary>
        [Test]
        public void OnGet_ReturnsEmpty()
        {
            // Arrange


            // Act
            pageModel.OnGet();

            // Assert
            Assert.That(pageModel.Question1Answer, Is.Null);
            Assert.That(pageModel.Question2Answer, Is.Null);
            Assert.That(pageModel.Question3Answer, Is.Null);
            Assert.That(pageModel.Question4Answer, Is.Null);
            Assert.That(pageModel.Question5Answer, Is.Null);
            Assert.That(pageModel.Question1, Is.EqualTo("1. In the event of unexpected expenses, what is the maximum amount you are willing to spend annually on your pet?"));
            Assert.That(pageModel.Question2, Is.EqualTo("2. How much time are you willing to spend cleaning up after your pets each day/week without feeling frustrated?"));
            Assert.That(pageModel.Question3, Is.EqualTo("3. How much time can you dedicate to spending with your pets after a busy day?"));
            Assert.That(pageModel.Question4, Is.EqualTo("4. Are you comfortable allowing your pet to roam free in your living space or do they need to be kept in a cage or tank?"));
            Assert.That(pageModel.Question5, Is.EqualTo("5. What is the reason behind your desire to have a pet?"));
        }

        /// <summary>
        /// Tests the OnGet method of the BlogAndStories page.
        /// </summary>
        [Test]
        public void OnGet_Valid_Activity_ShouldReturn_True()
        {
            // Arrange


            // Act
            pageModel.OnGet();



            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.Pets.ToList().Any());

        }
        #endregion OnGet
        
        /// <summary>
        /// Test question 1's output is as expected.
        /// </summary>
        [Test]
        public void TestQuestion1Answer()
        {
            // Arrange
         
            var expectedValue = "Test value";

            // Act
            pageModel.Question1Answer = expectedValue;

            // Assert
            Assert.AreEqual(expectedValue, pageModel.Question1Answer);
        }

        /// <summary>
        /// Test question 2's output is as expected.
        /// </summary>
        [Test]
        public void TestQuestion2Answer()
        {
            // Arrange

            var expectedValue = "Test value";

            // Act
            pageModel.Question2Answer = expectedValue;

            // Assert
            Assert.AreEqual(expectedValue, pageModel.Question2Answer);
        }

        /// <summary>
        /// Test question 3's output is as expected.
        /// </summary>
        [Test]
        public void TestQuestion3Answer()
        {
            // Arrange
  
            var expectedValue = "Test value";

            // Act
            pageModel.Question3Answer = expectedValue;

            // Assert
            Assert.AreEqual(expectedValue, pageModel.Question3Answer);
        }

        /// <summary>
        /// Test question 4's output is as expected.
        /// </summary>
        [Test]
        public void TestQuestion4Answer()
        {
            // Arrange

            var expectedValue = "Test value";

            // Act
            pageModel.Question4Answer = expectedValue;

            // Assert
            Assert.AreEqual(expectedValue, pageModel.Question4Answer);
        }

        /// <summary>
        /// test question 5's output is as expected.
        /// </summary>
        [Test]
        public void TestQuestion5Answer()
        {
            // Arrange

            var expectedValue = "Test value";

            // Act
            pageModel.Question5Answer = expectedValue;

            // Assert
            Assert.AreEqual(expectedValue, pageModel.Question5Answer);
        }

        /// <summary>
        /// Test answering question 1.
        /// </summary>
        [Test]
        public void SetQuestion1_ShouldUpdateQuestion1Value()
        {
            // Arrange

            var expectedValue = "What is your favorite color?";

            // Act
            pageModel.Question1 = expectedValue;

            // Assert
            Assert.AreEqual(expectedValue, pageModel.Question1);
        }

        /// <summary>
        /// Test answering question 2.
        /// </summary>
        [Test]
        public void SetQuestion2_ShouldUpdateQuestion1Value()
        {
            // Arrange

            var expectedValue = "What is your favorite dog?";

            // Act
            pageModel.Question2 = expectedValue;

            // Assert
            Assert.AreEqual(expectedValue, pageModel.Question2);
        }

        /// <summary>
        /// Test answering question 3.
        /// </summary>
        [Test]
        public void SetQuestion3_ShouldUpdateQuestion1Value()
        {
            // Arrange
       
            var expectedValue = "What is your favorite city?";

            // Act
            pageModel.Question3 = expectedValue;

            // Assert
            Assert.AreEqual(expectedValue, pageModel.Question3);
        }

        /// <summary>
        /// Test answering question 4.
        /// </summary>
        [Test]
        public void SetQuestion4_ShouldUpdateQuestion1Value()
        {
            // Arrange
  
            var expectedValue = "What is your favorite flower?";

            // Act
            pageModel.Question4 = expectedValue;

            // Assert
            Assert.AreEqual(expectedValue, pageModel.Question4);
        }

        /// <summary>
        /// Testing answering question 5.
        /// </summary>
        [Test]
        public void SetQuestion5_ShouldUpdateQuestion1Value()
        {
            // Arrange
   
            var expectedValue = "What is your favorite food?";

            // Act
            pageModel.Question5 = expectedValue;

            // Assert
            Assert.AreEqual(expectedValue, pageModel.Question5);
        }

        /// <summary>
        /// Testing OnPost method when points are 40.
        /// </summary>
        [Test]
        public void OnPost_ReturnsCorrectResult_ForPointValue40()
        {

            // Arrange

            pageModel.Question1Answer = "smallfish,largefish,other";
            pageModel.Question2Answer = "smallfish,largefish,other";
            pageModel.Question3Answer = "smallfish,largefish,other";
            pageModel.Question4Answer = "smallfish,largefish,other";
            pageModel.Question5Answer = "smallfish,largefish,other";


            // Act
            pageModel.OnPost();

            // Assert
            Assert.AreEqual("Your perfect pet can be a small pet such as hamster, chinchillas! They are the best choice for beginners", pageModel.Message);

        }

        /// <summary>
        /// Test OnPost method when points are 25.
        /// </summary>
        [Test]
        public void OnPost_ReturnsCorrectResult_ForPointValue25()
        {

            // Arrange

            pageModel.Question1Answer = "smallfish,largefish";
            pageModel.Question2Answer = "smallfish,largefish";
            pageModel.Question3Answer = "smallfish,largefish";
            pageModel.Question4Answer = "smallfish,largefish";
            pageModel.Question5Answer = "smallfish,largefish";


            // Act
            pageModel.OnPost();

            // Assert
            Assert.AreEqual("Your perfect pet can be a fish or a lot of fishes! They are cute and very easy to take care of", pageModel.Message);

        }

        /// <summary>
        /// Test OnPost method for when points are 74.
        /// </summary>
        [Test]
        public void OnPost_ReturnsCorrectResult_ForPointValue74()
        {
            // Arrange

            pageModel.Question1Answer = "smallfish,largefish,cat,other";
            pageModel.Question2Answer = "smallfish,largefish,cat";
            pageModel.Question3Answer = "smallfish,largefish,cat,other";
            pageModel.Question4Answer = "smallfish,largefish,cat,other";
            pageModel.Question5Answer = "smallfish,largefish,other,cat";


            // Act
            pageModel.OnPost();

            // Assert
            Assert.AreEqual("Your perfect pet can be a cat! They are calm and good companions", pageModel.Message);

        }

        /// <summary>
        /// Test OnPost method for when points are 79.
        /// </summary>
        [Test]
        public void OnPost_ReturnsCorrectResult_ForPointValue79()
        {
            // Arrange

            pageModel.Question1Answer = "smallfish,largefish,cat,other,smalldog";
            pageModel.Question2Answer = "smallfish,largefish,cat,mediumdog,smalldog";
            pageModel.Question3Answer = "smallfish,largefish,cat,other,smalldog";
            pageModel.Question4Answer = "smallfish,largefish,cat,other,mediumdog";
            pageModel.Question5Answer = "smallfish,largefish,other,cat,smalldog";

            // Act
            pageModel.OnPost();

            // Assert
            Assert.AreEqual("Your perfect pet can be a small or medium dog! They are cute and fun to play with", pageModel.Message);

        }

        /// <summary>
        /// Test OnPost method for when points are 80.
        /// </summary>
        [Test]
        public void OnPost_ReturnsCorrectResult_ForPointValue80()
        {
            // Arrange

            pageModel.Question1Answer = "smallfish,largefish,cat,other,smalldog,mediumdog,largedog";
            pageModel.Question2Answer = "smallfish,largefish,cat,mediumdog,smalldog,largedog";
            pageModel.Question3Answer = "smallfish,largefish,cat,other,mediumdog,smalldog,largedog";
            pageModel.Question4Answer = "smallfish,largefish,cat,other,mediumdog,smalldog,largedog";
            pageModel.Question5Answer = "smallfish,largefish,other,cat,mediumdog,smalldog,largedog";

            // Act
            pageModel.OnPost();

            // Assert
            Assert.AreEqual("Your perfect pet can be a big dog! They are very protective and loyal! They are a great companion!", pageModel.Message);
        }
    }
}
