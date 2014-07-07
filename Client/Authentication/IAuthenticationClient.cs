namespace VisualStudioIntegreate.Client.Authentication
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementing classes define methods for retrieving information to authenticate
    /// with an identity.
    /// </summary>
    public interface IAuthenticationClient
    {
        /// <summary>
        /// Build a <see cref="System.Uri"/> to execute to allow the user to accept
        /// or deny the <see cref="ConsumerApplication"/> access to the VSO REST API
        /// using their credentials.
        /// </summary>
        /// <param name="state">
        /// Authentication state information to pass into the redirect <see cref="System.Uri"/>.
        /// </param>
        /// <returns>
        /// A fully formed <see cref="System.Uri"/> to redirect too to gain an Access Token.
        /// </returns>
        Uri CreateAuthorizeUri(string state);

        /// <summary>
        /// From a call-back <paramref name="authorizationCode"/>, retrieve an
        /// <see cref="AccessToken"/> to query the API with.
        /// </summary>
        /// <param name="authorizationCode">The authorisation code to create an <see cref="AccessToken"/> with.</param>
        /// <returns>A populated <see cref="AccessToken"/>.</returns>
        Task<AccessToken> GetAccessToken(string authorizationCode);
    }
}