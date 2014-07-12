namespace VisualStudioIntegreate.Client.Project
{
    using System.Threading.Tasks;

    /// <summary>
    /// Implementing classes define methods for interacting with the Profiles section of the VSOI REST API.
    /// </summary>
    public interface IProfileClient
    {
        /// <summary>
        /// Retrieve the profile information for the given authentication context.
        /// </summary>
        /// <param name="context">The context under which to execute the request.</param>
        /// <returns>The profile information for the given authentication context.</returns>
        Task<Profile> GetAuthenticatedClientProfileAsync(IAuthenticatedVisualStudioIntegrateContext context);
    }
}