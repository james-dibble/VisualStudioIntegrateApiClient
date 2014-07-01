namespace UnitTests.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VisualStudioIntegreate.Client;
    using VisualStudioIntegreate.Client.Authentication;

    [TestClass]
    public class AuthenticationClientTests
    {
        [TestMethod]
        public void TestCreateAuthorizationUri()
        {
            var fakeApplication = new ConsumerApplication
            {
                AccessTokenUrl = new Uri("http://somewhere.com"),
                ApplicationId = "Some api id",
                ApplicationSecret = "Some really long boring string",
                AuthorizedScopes = new List<string> {"I can do this", "I can do that"},
                AuthorizeUrl = new Uri("http://somewhere.com/authorize"),
                CallbackUri = new Uri("http://somewhere.com")
            };

            var target = new AuthenticationClient(fakeApplication);

            var actual = target.CreateAuthorizeUri(string.Empty);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.AbsoluteUri.StartsWith(fakeApplication.AuthorizeUrl.AbsoluteUri));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task TestGetAccessTokenEmptyAuthCode()
        {
            var target = new AuthenticationClient(new ConsumerApplication());

            await target.GetAccessToken(string.Empty);
        }

        [TestMethod]
        public async Task TestGetAccessToken()
        {
            var target = new AuthenticationClient(new ConsumerApplication());

            var actual = await target.GetAccessToken("any string");

            Assert.IsNotNull(actual);
        }
    }
}