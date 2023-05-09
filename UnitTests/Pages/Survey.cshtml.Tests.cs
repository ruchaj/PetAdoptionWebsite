using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitTests.Pages
{
    public class Survey
    {
        [Test]
        public void GetPoint_ReturnsCorrectPoint()
        {
            // Arrange
            var model = new SurveyModel();
            var responses = new[] { "smallfish", "largefish", "cat", "smalldog", "other", "mediumdog", "largedog" };

            // Act
            var point = model.GetPoint(responses);

            // Assert
            Assert.AreEqual(28, point);
        }


        [Test]
        public void OnGet_ReturnsEmpty()
        {
            // Arrange
            var model = new SurveyModel();

            // Act
            model.OnGet();

            // Assert
            Assert.That(model.Question1Answer, Is.Null);
            Assert.That(model.Question2Answer, Is.Null);
            Assert.That(model.Question3Answer, Is.Null);
            Assert.That(model.Question4Answer, Is.Null);
            Assert.That(model.Question5Answer, Is.Null);
            Assert.That(model.Question1, Is.EqualTo("1. In the event of unexpected expenses, what is the maximum amount you are willing to spend annually on your pet?"));
            Assert.That(model.Question2, Is.EqualTo("2. How much time are you willing to spend cleaning up after your pets each day/week without feeling frustrated?"));
            Assert.That(model.Question3, Is.EqualTo("3. How much time can you dedicate to spending with your pets after a busy day?"));
            Assert.That(model.Question4, Is.EqualTo("4. Are you comfortable allowing your pet to roam free in your living space or do they need to be kept in a cage or tank?"));
            Assert.That(model.Question5, Is.EqualTo("5. What is the reason behind your desire to have a pet?"));
        }

        [Test]
        public void TestQuestion1Answer()
        {
            // Arrange
            var model = new SurveyModel();
            var expectedValue = "Test value";

            // Act
            model.Question1Answer = expectedValue;

            // Assert
            Assert.AreEqual(expectedValue, model.Question1Answer);
        }

        [Test]
        public void TestQuestion2Answer()
        {
            // Arrange
            var model = new SurveyModel();
            var expectedValue = "Test value";

            // Act
            model.Question2Answer = expectedValue;

            // Assert
            Assert.AreEqual(expectedValue, model.Question2Answer);
        }

        [Test]
        public void TestQuestion3Answer()
        {
            // Arrange
            var model = new SurveyModel();
            var expectedValue = "Test value";

            // Act
            model.Question3Answer = expectedValue;

            // Assert
            Assert.AreEqual(expectedValue, model.Question3Answer);
        }

        [Test]
        public void TestQuestion4Answer()
        {
            // Arrange
            var model = new SurveyModel();
            var expectedValue = "Test value";

            // Act
            model.Question4Answer = expectedValue;

            // Assert
            Assert.AreEqual(expectedValue, model.Question4Answer);
        }

        [Test]
        public void TestQuestion5Answer()
        {
            // Arrange
            var model = new SurveyModel();
            var expectedValue = "Test value";

            // Act
            model.Question5Answer = expectedValue;

            // Assert
            Assert.AreEqual(expectedValue, model.Question5Answer);
        }

        [Test]
        public void SetQuestion1_ShouldUpdateQuestion1Value()
        {
            // Arrange
            var survey = new SurveyModel();
            var expectedValue = "What is your favorite color?";

            // Act
            survey.Question1 = expectedValue;

            // Assert
            Assert.AreEqual(expectedValue, survey.Question1);
        }

        [Test]
        public void SetQuestion2_ShouldUpdateQuestion1Value()
        {
            // Arrange
            var survey = new SurveyModel();
            var expectedValue = "What is your favorite dog?";

            // Act
            survey.Question2 = expectedValue;

            // Assert
            Assert.AreEqual(expectedValue, survey.Question2);
        }

        [Test]
        public void SetQuestion3_ShouldUpdateQuestion1Value()
        {
            // Arrange
            var survey = new SurveyModel();
            var expectedValue = "What is your favorite city?";

            // Act
            survey.Question3 = expectedValue;

            // Assert
            Assert.AreEqual(expectedValue, survey.Question3);
        }

        [Test]
        public void SetQuestion4_ShouldUpdateQuestion1Value()
        {
            // Arrange
            var survey = new SurveyModel();
            var expectedValue = "What is your favorite flower?";

            // Act
            survey.Question4 = expectedValue;

            // Assert
            Assert.AreEqual(expectedValue, survey.Question4);
        }

        [Test]
        public void SetQuestion5_ShouldUpdateQuestion1Value()
        {
            // Arrange
            var survey = new SurveyModel();
            var expectedValue = "What is your favorite food?";

            // Act
            survey.Question5 = expectedValue;

            // Assert
            Assert.AreEqual(expectedValue, survey.Question5);
        }

        [Test]
        public void OnPost_ReturnsCorrectResult_ForPointValue40()
        {

            // Arrange
            var surveyPageModel = new SurveyModel();
            surveyPageModel.Question1Answer = "smallfish,largefish,other";
            surveyPageModel.Question2Answer = "smallfish,largefish,other";
            surveyPageModel.Question3Answer = "smallfish,largefish,other";
            surveyPageModel.Question4Answer = "smallfish,largefish,other";
            surveyPageModel.Question5Answer = "smallfish,largefish,other";


            // Act
            surveyPageModel.OnPost();

            // Assert
            Assert.AreEqual("Your perfect pet can be a small pet such as hamster, chinchillas! They are the best choice for beginners", surveyPageModel.Message);

        }


        [Test]
        public void OnPost_ReturnsCorrectResult_ForPointValue25()
        {

            // Arrange
            var surveyPageModel = new SurveyModel();
            surveyPageModel.Question1Answer = "smallfish,largefish";
            surveyPageModel.Question2Answer = "smallfish,largefish";
            surveyPageModel.Question3Answer = "smallfish,largefish";
            surveyPageModel.Question4Answer = "smallfish,largefish";
            surveyPageModel.Question5Answer = "smallfish,largefish";


            // Act
            surveyPageModel.OnPost();

            // Assert
            Assert.AreEqual("Your perfect pet can be a fish or a lot of fishes! They are cute and very easy to take care of", surveyPageModel.Message);

        }

        [Test]
        public void OnPost_ReturnsCorrectResult_ForPointValue74()
        {

            // Arrange
            var surveyPageModel = new SurveyModel();
            surveyPageModel.Question1Answer = "smallfish,largefish,cat,other";
            surveyPageModel.Question2Answer = "smallfish,largefish,cat";
            surveyPageModel.Question3Answer = "smallfish,largefish,cat,other";
            surveyPageModel.Question4Answer = "smallfish,largefish,cat,other";
            surveyPageModel.Question5Answer = "smallfish,largefish,other,cat";


            // Act
            surveyPageModel.OnPost();

            // Assert
            Assert.AreEqual("Your perfect pet can be a cat! They are calm and good companions", surveyPageModel.Message);

        }

        [Test]
        public void OnPost_ReturnsCorrectResult_ForPointValue79()
        {

            // Arrange
            var surveyPageModel = new SurveyModel();
            surveyPageModel.Question1Answer = "smallfish,largefish,cat,other,smalldog";
            surveyPageModel.Question2Answer = "smallfish,largefish,cat,mediumdog,smalldog";
            surveyPageModel.Question3Answer = "smallfish,largefish,cat,other,smalldog";
            surveyPageModel.Question4Answer = "smallfish,largefish,cat,other,mediumdog";
            surveyPageModel.Question5Answer = "smallfish,largefish,other,cat,smalldog";


            // Act
            surveyPageModel.OnPost();

            // Assert
            Assert.AreEqual("Your perfect pet can be a small or medium dog! They are cute and fun to play with", surveyPageModel.Message);

        }

        [Test]
        public void OnPost_ReturnsCorrectResult_ForPointValue80()
        {

            // Arrange
            var surveyPageModel = new SurveyModel();
            surveyPageModel.Question1Answer = "smallfish,largefish,cat,other,smalldog,mediumdog,largedog";
            surveyPageModel.Question2Answer = "smallfish,largefish,cat,mediumdog,smalldog,largedog";
            surveyPageModel.Question3Answer = "smallfish,largefish,cat,other,mediumdog,smalldog,largedog";
            surveyPageModel.Question4Answer = "smallfish,largefish,cat,other,mediumdog,smalldog,largedog";
            surveyPageModel.Question5Answer = "smallfish,largefish,other,cat,mediumdog,smalldog,largedog";


            // Act
            surveyPageModel.OnPost();

            // Assert
            Assert.AreEqual("Your perfect pet can be a big dog! They are very protective and loyal! They are a great companion!", surveyPageModel.Message);

        }



    }
}
