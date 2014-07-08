namespace VisualStudioIntegreate.Client
{
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementing classes define an execution context for requests to the VSOI API using an identity.
    /// </summary>
    public interface IAuthenticatedVisualStudioIntegrateContext : IVisualStudioIntegrateContext
    {
        /// <summary>
        /// Process the given <see cref="AuthenticatedRequest"/>.
        /// </summary>
        /// <param name="request">The <see cref="AuthenticatedRequest"/> to execute.</param>
        /// <returns>An awaitable object for the execute operation.</returns>
        Task<HttpResponseMessage> ExecuteAsync(AuthenticatedRequest request);

        /// <summary>
        /// Process the given <paramref name="request"/> and extract an object from it.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the <paramref name="request"/>.</typeparam>
        /// <param name="request">The <see cref="AuthenticatedRequest"/> to execute.</param>
        /// <returns>An awaitable object for the execute operation.</returns>
        Task<T> ExecuteAsync<T>(AuthenticatedRequest<T> request);
    }
}