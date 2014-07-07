namespace VisualStudioIntegreate.Client
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    /// <summary>
    /// An implementation of <see cref="IRestClient"/>.
    /// </summary>
    public class RestClient : IRestClient
    {
        private readonly ConsumerApplication _consumerApplication;

        /// <summary>
        /// Initialises a new instance of the <see cref="RestClient"/> class.
        /// </summary>
        /// <param name="consumerApplication">The parent application information.</param>
        public RestClient(ConsumerApplication consumerApplication)
        {
            this._consumerApplication = consumerApplication;
        }

        /// <summary>
        /// Perform a request upon the API.
        /// </summary>
        /// <param name="request">The content of the request to be sent.</param>
        /// <returns>The response from the server.</returns>
        public async Task<HttpResponseMessage> ExecuteRequestAsync(HttpRequestMessage request)
        {
            Guard.IsNotNull(request, "request", "The request to be sent cannot be null.");

            request.Properties.Add("client_assertion_type", "urn:ietf:params:oauth:client-assertion-type:jwt-bearer");
            request.Properties.Add("client_assertion", this._consumerApplication.ApplicationSecret);

            using (var client = new HttpClient())
            {
                return await client.SendAsync(request);
            }
        }

        /// <summary>
        /// Perform a request upon the API and parse its response as JSON into an object.
        /// </summary>
        /// <param name="request">The content of the request to be sent.</param>
        /// <typeparam name="T">The type expected to be returned.</typeparam>
        /// <returns>The object in .Net form.</returns>
        public async Task<T> ExecuteRequestAsync<T>(HttpRequestMessage request) where T : new()
        {
            var response = await this.ExecuteRequestAsync(request);

            response = response.EnsureSuccessStatusCode();

            var parsed = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());

            return parsed;
        }
    }
}