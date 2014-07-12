namespace VisualStudioIntegreate.Client.Project
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementing classes define methods for extracting information about Team Projects.
    /// </summary>
    public interface IProjectClient
    {
        /// <summary>
        /// Using the authenticated clients information, retrieve the Team Projects they are authorized to access in a given account.
        /// </summary>
        /// <param name="context">The context under which to execute the request.</param>
        /// <param name="account">The Visual Studio Online account to query.</param>
        /// <returns>A collection of <see cref="Project"/> objects.</returns>
        Task<IEnumerable<Project>> GetAuthenicatedClientsProjectsAsync(IAuthenticatedVisualStudioIntegrateContext context, string account);
    }
}