namespace VisualStudioIntegreate.Client.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// The default implementation of <see cref="IAuthenticationClient"/>.
    /// </summary>
    public class AuthenticationClient : IAuthenticationClient
    {
        private readonly ConsumerApplication _consumerApplication;

        /// <summary>
        /// Initialises a new instance of the <see cref="AuthenticationClient"/> class.
        /// </summary>
        /// <param name="applicationIdentity">Authentication information for the parent application.</param>
        public AuthenticationClient(ConsumerApplication applicationIdentity)
        {
            Guard.IsNotNull(applicationIdentity, "applicationIdentity", "An authentication client must have an application identity.");

            this._consumerApplication = applicationIdentity;
        }

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
        public Uri CreateAuthorizeUri(string state)
        {
            const string GetParamertsFormat = @"?client_id={0}&response_type=Assertion&state={1}&scope={2}&redirect_uri={3}";

            var populatedGetParameters = string.Format(
                CultureInfo.InvariantCulture,
                GetParamertsFormat,
                this._consumerApplication.ApplicationId,
                state,
                string.Join(" ", this._consumerApplication.AuthorizedScopes),
                this._consumerApplication.CallbackUri);

            var formedAuthorizeUri = new Uri(this._consumerApplication.AuthorizeUrl, populatedGetParameters);

            return formedAuthorizeUri;
        }

        /// <summary>
        /// From a call-back <paramref name="authorizationCode"/>, retrieve an
        /// <see cref="AccessToken"/> to query the API with.
        /// </summary>
        /// <param name="context">The context in which to execute the request.</param>
        /// <param name="authorizationCode">The authorisation code to create an <see cref="AccessToken"/> with.</param>
        /// <returns>A populated <see cref="AccessToken"/>.</returns>
        public async Task<AccessToken> GetAccessTokenAsync(IVisualStudioIntegrateContext context, string authorizationCode)
        {
            Guard.IsNot(
                authorizationCode,
                code => !string.IsNullOrEmpty(code),
                "authorizationCode",
                "To get an access token an authorization code must be supplied.");

            var request = new Request<AccessTokenDto>
            {
                Method = HttpMethod.Post,
                RequestUri = this._consumerApplication.AccessTokenUrl,
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "grant_type", "urn:ietf:params:oauth:grant-type:jwt-bearer" },
                    { "assertion", authorizationCode },
                    { "redirect_uri", this._consumerApplication.CallbackUri.AbsoluteUri },
                    { "client_assertion_type", "urn:ietf:params:oauth:client-assertion-type:jwt-bearer" },
                    { "client_assertion", this._consumerApplication.ApplicationSecret }
                })
            };

            var response = await context.ExecuteAsync(request);

            var token = new AccessToken(
                response.AccessToken,
                response.ExpiresIn,
                this._consumerApplication.AccessTokenUrl,
                response.RefreshToken);

            return token;
        }

        /// <summary>
        /// Update the access code for an expired <see cref="AccessToken"/>.
        /// </summary>
        /// <param name="context">The context in which to execute the request.</param>
        /// <param name="currentToken">The current identity information.</param>
        /// <returns>A new <see cref="AccessToken"/>.</returns>
        public async Task<AccessToken> RefreshAccessTokenAsync(IVisualStudioIntegrateContext context, AccessToken currentToken)
        {
            var request = new Request<AccessTokenDto>
            {
                Method = HttpMethod.Post,
                RequestUri = this._consumerApplication.AccessTokenUrl,
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "grant_type", "refresh_token" },
                    { "assertion", currentToken.RefreshToken },
                    { "redirect_uri", this._consumerApplication.CallbackUri.AbsoluteUri },
                    { "client_assertion_type", "urn:ietf:params:oauth:client-assertion-type:jwt-bearer" },
                    { "client_assertion", this._consumerApplication.ApplicationSecret }
                })
            };

            var response = await context.ExecuteAsync(request);

            var refreshedToken = new AccessToken(
                response.AccessToken,
                response.ExpiresIn,
                this._consumerApplication.AccessTokenUrl,
                response.RefreshToken);

            return refreshedToken;
        }
    }
}