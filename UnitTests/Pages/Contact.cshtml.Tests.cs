using System.Diagnostics;

using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Moq;

using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages.Contact
{
    /// <summary>
    /// A class to test the Contact.cshtml.cs page.
    /// </summary>
    public class ContactTests
    {
        #region TestSetup
        /// <summary>
        /// Create a public page model for ContactModel testing.
        /// </summary>
        public static ContactModel pageModel;

        /// <summary>
        /// Set up the tests herein.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<ContactModel>>();

        }
        #endregion TestSetup
    }
}
