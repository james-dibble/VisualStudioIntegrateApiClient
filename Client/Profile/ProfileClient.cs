namespace VisualStudioIntegreate.Client.Profile
{
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// A default implementation of the <see cref="IProfileClient"/> interface.
    /// </summary>
    public class ProfileClient : IProfileClient
    {
        /// <summary>
        /// Retrieve the profile information for the given authentication context.
        /// </summary>
        /// <param name="context">The context under which to execute the request.</param>
        /// <returns>The profile information for the given authentication context.</returns>
        public async Task<Profile> GetAuthenticatedClientProfileAsync(IAuthenticatedVisualStudioIntegrateContext context)
        {
            var request = new AuthenticatedRequest<Profile> { Method = HttpMethod.Get };

            var response = await context.ExecuteAsync(request);

            return response;
        }
    }
}