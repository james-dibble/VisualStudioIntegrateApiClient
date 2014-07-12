namespace VisualStudioIntegreate.Client.Project
{
    using System.Collections.Generic;

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
        public IEnumerable<Project> GetAuthenicatedClientsProjects(IAuthenticatedVisualStudioIntegrateContext context, string account)
        {
            throw new System.NotImplementedException();
        }
    }
}