namespace UnitTests.Project
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using VisualStudioIntegreate.Client;
    using VisualStudioIntegreate.Client.Profile;
    using VisualStudioIntegreate.Client.Project;

    [TestClass]
    public class ProjectClientTests
    {
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public async Task TestGetAuthenicatedClientsProjectsNullContext()
        {
            var target = new ProjectClient();

            await target.GetAuthenicatedClientsProjectsAsync(null, "Something");
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public async Task TestGetAuthenicatedClientsProjectsNullAccount()
        {
            var fakeContext = new Mock<IAuthenticatedVisualStudioIntegrateContext>();

            var target = new ProjectClient();

            await target.GetAuthenicatedClientsProjectsAsync(fakeContext.Object, string.Empty);
        }

        [TestMethod]
        public async Task TestGetAuthenicatedClientsProjects()
        {
            var fakeProfiles = new List<Profile>
            {
                new Profile()
            };

            var fakeContext = new Mock<IAuthenticatedVisualStudioIntegrateContext>();
            fakeContext
                .Setup(x => x.ExecuteAsync(It.IsAny<AuthenticatedRequest<ProfileCollectionDto>>()))
                .Returns(() => Task.Run(() => new ProfileCollectionDto { Value = fakeProfiles }));

            var target = new ProjectClient();

            var actual = await target.GetAuthenicatedClientsProjectsAsync(fakeContext.Object, "Something");

            Assert.AreEqual(fakeProfiles, actual);
        }
    }
}