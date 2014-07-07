namespace VisualStudioIntegreate.Client
{
    using VisualStudioIntegreate.Client.Authentication;

    /// <summary>
    /// Implementing classes define methods for interacting with the 
    /// VSO REST API.
    /// </summary>
    public interface IVisualStudioIntegrateClient
    {
        /// <summary>
        /// Gets methods for Authenticating with the VSO REST API using an identity.
        /// </summary>
        IAuthenticationClient Authentication { get; }
    }
}