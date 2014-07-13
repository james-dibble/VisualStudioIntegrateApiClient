namespace VisualStudioIntegreate.Client.Project
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net.Http;
    using System.Threading.Tasks;
    using VisualStudioIntegreate.Client.Project;

    /// <summary>
    /// A default implementation of the <see cref="IProjectClient"/> interface.
    /// </summary>
    public class ProjectClient : IProjectClient
    {
        /// <summary>
        /// Using the authenticated clients information, retrieve the Team Projects they are authorized to access in a given account.
        /// </summary>
        /// <param name="context">The context under which to execute the request.</param>
        /// <param name="account">The Visual Studio Online account to query.</param>
        /// <returns>A collection of <see cref="Project"/> objects.</returns>
        public async Task<IEnumerable<Project>> GetAuthenicatedClientsProjectsAsync(IAuthenticatedVisualStudioIntegrateContext context, string account)
        {
            Guard.IsNotNull(context, "context", "API Context cannot be null.");
            Guard.IsNot(account, arg => !string.IsNullOrEmpty(arg), "account", "The VSO account cannot be empty");

            var request = new AuthenticatedRequest<ProjectCollectionDto>
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "https://{0}.visualstudio.com/defaultcollection/_apis/projects?includeCapabilities=true",
                        account))
            };

            var container = await context.ExecuteAsync(request);

            return container.Value;
        }
    }
}