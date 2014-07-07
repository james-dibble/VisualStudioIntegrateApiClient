namespace VisualStudioIntegreate.Client
{
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementing classes define methods for sending HTTP requests to the 
    /// API.
    /// </summary>
    public interface IRestClient
    {
        /// <summary>
        /// Perform a request upon the API.
        /// </summary>
        /// <param name="request">The content of the request to be sent.</param>
        /// <returns>The raw response from the server.</returns>
        Task<HttpResponseMessage> ExecuteRequestAsync(HttpRequestMessage request);

        /// <summary>
        /// Perform a request upon the API and parse its response as JSON into an object.
        /// </summary>
        /// <param name="request">The content of the request to be sent.</param>
        /// <typeparam name="T">The type expected to be returned.</typeparam>
        /// <returns>The object in .Net form.</returns>
        Task<T> ExecuteRequestAsync<T>(HttpRequestMessage request) where T : new();
    }
}