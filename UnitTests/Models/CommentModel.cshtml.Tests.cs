using NUnit.Framework;
using System.Text.Json;

namespace ContosoCrafts.WebSite.Models.Tests
{
    /// <summary>
    /// A class to test CommentModel.
    /// </summary>
    public class CommentModelTests
    {
        /// <summary>
        /// Checks if the comment has a set ID
        /// </summary>
        [Test]
        public void Id_ShouldGenerateNonEmptyString()
        {
            // Arrange
            var comment = new CommentModel();

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(comment.Id));
        }
        /// <summary>
        /// Checks if the comment(s) has/have a unique ID
        /// </summary>
        [Test]
        public void Id_ShouldGenerateUniqueIdentifiers()
        {
            // Arrange
            var comment1 = new CommentModel();
            var comment2 = new CommentModel();

            // Assert
            Assert.AreNotEqual(comment1.Id, comment2.Id);
        }
        /// <summary>
        /// Checks if changing the id updates the id through setting
        /// </summary>
        [Test]
        public void Id_Set_ShouldUpdateIdValue()
        {
            // Arrange
            var comment = new CommentModel();
            var newId = "new-id";

            // Act
            typeof(CommentModel).GetProperty("Id").SetValue(comment, newId);

            // Assert
            Assert.AreEqual(newId, comment.Id);
        }

    }
}
