namespace VisualStudioIntegreate.Client
{
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    using VisualStudioIntegreate.Client.Authentication;

    /// <summary>
    /// An execution context for queries against the VSOI API using an identity.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly", Justification = "IDisposable implemented only once.")]
    public class AuthenticatedVisualStudioIntegrateContext : VisualStudioIntegrateContext, IAuthenticatedVisualStudioIntegrateContext
    {
        private readonly AccessToken _accessToken;

        /// <summary>
        /// Initialises a new instance of the <see cref="AuthenticatedVisualStudioIntegrateContext"/> class.
        /// </summary>
        /// <param name="accessToken">The current identity to use for executing queries.</param>
        /// <param name="consumerApplication">The access information for the parent application.</param>
        public AuthenticatedVisualStudioIntegrateContext(AccessToken accessToken, ConsumerApplication consumerApplication)
            : base(consumerApplication)
        {
            this._accessToken = accessToken;
        }

        /// <summary>
        /// Process the given <see cref="AuthenticatedRequest"/>.
        /// </summary>
        /// <param name="request">The <see cref="AuthenticatedRequest"/> to execute.</param>
        /// <returns>An awaitable object for the execute operation.</returns>
        public async Task<HttpResponseMessage> ExecuteAsync(AuthenticatedRequest request)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue(
                "Authorization",
                string.Concat("bearer ", this._accessToken.Token));

            return await this.ExecuteAsync(request as Request);
        }

        /// <summary>
        /// Process the given <paramref name="request"/> and extract an object from it.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the <paramref name="request"/>.</typeparam>
        /// <param name="request">The <see cref="AuthenticatedRequest"/> to execute.</param>
        /// <returns>An awaitable object for the execute operation.</returns>
        public async Task<T> ExecuteAsync<T>(AuthenticatedRequest<T> request)
        {
            var response = await this.ExecuteAsync(request as AuthenticatedRequest);

            return await this.ParseResponse<T>(response);
        }
    }
}