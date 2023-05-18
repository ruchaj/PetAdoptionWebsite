using Bunit;
using NUnit.Framework;
using ContosoCrafts.WebSite.Components;
using Microsoft.Extensions.DependencyInjection;
using ContosoCrafts.WebSite.Services;
using System.Linq;

namespace UnitTests.Components
{
    public class ProductListTests : BunitTestContext
    {
        #region TestSetup

        /// <summary>
        /// Initialize the tests herein
        /// </summary>
        [SetUp]
        public void TestInitialize() { }

        #endregion TestSetup

        #region FeaturedProductList
        /// <summary>
        /// A unit test to verify the featured product list exists
        /// </summary>
        [Test]
        public void ProductList_Featured_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act
            var page = RenderComponent<ProductList>();

            // Get the pets returned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains("Wolfie"));
        }
        #endregion FeaturedProductList

        #region SubmitRatingNoExistingVotes
        /// <summary>
        /// A unit test to check the function of submitting a vote for a pet that has no existing votes
        /// </summary>
        [Test]
        public void SubmitRating_ValidID_ClickUnstarred_ShouldIncrementCount_AndCheckStars()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var id = "MoreInfoButton_2";
            var page = RenderComponent<ProductList>();
            var buttonList = page.FindAll("Button");

            // Locate and click the 'more info' button for ID = 2, Gamma (who has 2 ratings/votes)
            var button = buttonList.First(m => m.OuterHtml.Contains(id));
            button.Click();

            // Get the markup of the page after clicking 'more info' for Gamma
            var buttonMarkup = page.Markup;

            // Get the star buttons (for the votes)
            var starButtonList = page.FindAll("span");

            // Get vote count
            var preVoteCountSpan = starButtonList[1];
            var preVoteCountString = preVoteCountSpan.OuterHtml;

            // Get the first star item from the list (should not be checked bc Gamma has 0 votes)
            var starButton = starButtonList.First(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star"));

            // Save the html as the pre-change view of votes
            var preStarChange = starButton.OuterHtml;

            // Act
            //Click the star button to submit a rating for Gamma
            starButton.Click();

            // Get the markup to use for the assert
            buttonMarkup = page.Markup;

            // Get the star buttons (for the votes)
            starButtonList = page.FindAll("span");

            // Get the vote count
            var postVoteCountSpan = starButtonList[1];
            var postVoteCountString = postVoteCountSpan.OuterHtml;

            // Get the last starred element
            starButton = starButtonList.First(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star checked"));

            // Save the html as the post-change view of votes
            var postStarChange = starButton.OuterHtml;

            // Assert
            // Confirm that the pet had no votes to start, and 1 vote after
            Assert.AreEqual(true, preVoteCountString.Contains("Be the first to vote!"));
            Assert.AreEqual(true, postVoteCountString.Contains("1 Vote"));
            Assert.AreEqual(false, preVoteCountString.Equals(postVoteCountString));
        }
        #endregion SubmitRatingNoExistingVotes

        #region SubmitRatingExistingVotes
        /// <summary>
        /// A unit test to test the function of submitting a vote for a pet that already has votes
        /// </summary>
        [Test]
        public void SubmitRating_ValidID_ClickStarred_ShouldIncrementCount_AndLeaveStarCheckRemaining()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var id = "MoreInfoButton_1";
            var page = RenderComponent<ProductList>();
            var buttonList = page.FindAll("Button");

            // Locate and click the 'more info' button for ID = 1, Wolfie (who has 3 ratings/votes)
            var button = buttonList.First(m => m.OuterHtml.Contains(id));
            button.Click();

            // Get the markup of the page after clicking 'more info' for Wolfie
            var buttonMarkup = page.Markup;

            // Get the star buttons (for the votes)
            var starButtonList = page.FindAll("span");

            // Get vote count
            var preVoteCountSpan = starButtonList[1];
            var preVoteCountString = preVoteCountSpan.OuterHtml;

            // Get the last star item from the list
            var starButton = starButtonList.Last(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star checked"));

            // Save the html as is, to compare to post-submitting a rating
            var preStarChange = starButton.OuterHtml;

            // Act
            // Click the star button
            starButton.Click();

            // Get the markup for assert
            buttonMarkup = page.Markup;

            // Get the Star Buttons
            starButtonList = page.FindAll("span");

            // Get vote count
            var postVoteCountSpan = starButtonList[1];
            var postVoteCountString = postVoteCountSpan.OuterHtml;

            // Get the last starred item from the list
            starButton = starButtonList.Last(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star checked"));

            // Save the html as is, as the post-submit view
            var postStarChange = starButton.OuterHtml;

            // Assert
            Assert.AreEqual(true, preVoteCountString.Contains("3 Votes"));
            Assert.AreEqual(true, postVoteCountString.Contains("4 Votes"));
            Assert.AreEqual(false, preVoteCountString.Equals(postVoteCountString));
        }
        #endregion SubmitRatingExistingVotes
    }
}
