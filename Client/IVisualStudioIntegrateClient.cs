namespace VisualStudioIntegreate.Client
{
    using VisualStudioIntegreate.Client.Authentication;

    /// <summary>
    /// Implementing classes define methods for interacting with the 
    /// VSO REST API.
    /// </summary>
    public interface IVisualStudioIntegrateClient
    {
        IAuthenticationClient Authentication { get; }
    }
}