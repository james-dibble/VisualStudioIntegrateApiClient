namespace UnitTests.Profile
{
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using VisualStudioIntegreate.Client;
    using VisualStudioIntegreate.Client.Project;

    [TestClass]
    public class ProfileClientTests
    {
        [TestMethod]
        public async Task TestGetAuthenticatedClientProfile()
        {
            var fakeContext = new Mock<IAuthenticatedVisualStudioIntegrateContext>();

            fakeContext
                .Setup(x => x.ExecuteAsync(It.IsAny<AuthenticatedRequest<Profile>>()))
                .Returns(Task.Run(() => new Profile()));

            var target = new ProfileClient();

            var actual = await target.GetAuthenticatedClientProfileAsync(fakeContext.Object);

            Assert.IsNotNull(actual);
        }
    }
}
