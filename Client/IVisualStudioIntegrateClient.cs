namespace VisualStudioIntegreate.Client
{
    using VisualStudioIntegreate.Client.Authentication;
    using VisualStudioIntegreate.Client.Project;

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

        /// <summary>
        /// Gets methods for retrieving profile information.
        /// </summary>
        IProfileClient Profile { get; }
    }
}