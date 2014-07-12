namespace UnitTests.Project
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using VisualStudioIntegreate.Client;
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
            var fakeProjects = new List<Project>
            {
                new Project()
            };

            var fakeContext = new Mock<IAuthenticatedVisualStudioIntegrateContext>();
            fakeContext
                .Setup(x => x.ExecuteAsync(It.IsAny<AuthenticatedRequest<ProjectCollectionDto>>()))
                .Returns(() => Task.Run(() => new ProjectCollectionDto { Value = fakeProjects }));

            var target = new ProjectClient();

            var actual = await target.GetAuthenicatedClientsProjectsAsync(fakeContext.Object, "Something");

            Assert.AreEqual(fakeProjects, actual);
        }
    }
}