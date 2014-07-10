namespace VisualStudioIntegreate.Client
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    /// <summary>
    /// An execution context for queries against the VSOI API.
    /// </summary>
    public class VisualStudioIntegrateContext : IVisualStudioIntegrateContext
    {
        private readonly HttpClient _httpClient;
        private readonly ConsumerApplication _consumerApplication;

        /// <summary>
        /// Initialises a new instance of the <see cref="VisualStudioIntegrateContext"/> class.
        /// </summary>
        /// <param name="consumerApplication">The parent application information.</param>
        public VisualStudioIntegrateContext(ConsumerApplication consumerApplication)
        {
            this._httpClient = new HttpClient();
            this._consumerApplication = consumerApplication;
        }

        /// <summary>
        /// Process the given <see cref="Request"/>.
        /// </summary>
        /// <param name="request">The <see cref="Request"/> to execute.</param>
        /// <returns>An awaitable object for the execute operation.</returns>
        public async Task<HttpResponseMessage> ExecuteAsync(Request request)
        {
            Guard.IsNotNull(request, "request", "The request to be sent cannot be null.");
            
            return await this._httpClient.SendAsync(request);
        }

        /// <summary>
        /// Process the given <paramref name="request"/> and extract an object from it.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the <paramref name="request"/>.</typeparam>
        /// <param name="request">The <see cref="Request"/> to execute.</param>
        /// <returns>An awaitable object for the execute operation.</returns>
        public async Task<T> ExecuteAsync<T>(Request<T> request)
        {
            var response = await this.ExecuteAsync(request as Request);

            return await this.ParseResponse<T>(response);
        }

        /// <summary>
        /// Defines a method to release allocated resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Extract an object from an <see cref="HttpResponseMessage"/>.
        /// </summary>
        /// <param name="response">The response that contains the object.</param>
        /// <typeparam name="T">The type of object to extract.</typeparam>
        /// <returns>The object in the <paramref name="response"/>.</returns>
        protected async Task<T> ParseResponse<T>(HttpResponseMessage response)
        {
            response = response.EnsureSuccessStatusCode();

            var parsed = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());

            return parsed;
        }

        /// <summary>
        /// A call to Dispose(true) should clean up both managed and native resources.
        /// </summary>
        /// <param name="disposing">Whether to dispose managed resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            this._httpClient.Dispose();
        }
    }
}