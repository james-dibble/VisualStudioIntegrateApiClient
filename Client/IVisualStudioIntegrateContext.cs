namespace VisualStudioIntegreate.Client
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementing classes define an execution context for requests to the VSOI API.
    /// </summary>
    public interface IVisualStudioIntegrateContext : IDisposable
    {
        /// <summary>
        /// Process the given <see cref="Request"/>.
        /// </summary>
        /// <param name="request">The <see cref="Request"/> to execute.</param>
        /// <returns>An awaitable object for the execute operation.</returns>
        Task<HttpResponseMessage> ExecuteAsync(Request request);
        
        /// <summary>
        /// Process the given <paramref name="request"/> and extract an object from it.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the <paramref name="request"/>.</typeparam>
        /// <param name="request">The <see cref="Request"/> to execute.</param>
        /// <returns>An awaitable object for the execute operation.</returns>
        Task<T> ExecuteAsync<T>(Request<T> request);
    }
}
