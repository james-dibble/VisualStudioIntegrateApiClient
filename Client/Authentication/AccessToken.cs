namespace VisualStudioIntegreate.Client.Authentication
{
    using System;

    /// <summary>
    /// A value object for storing information required to access the API using an identity.
    /// </summary>
    public struct AccessToken
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="AccessToken"/> struct.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="expiresIn">The number of seconds until the <paramref name="token"/> expires.</param>
        /// <param name="refreshUri">The refresh <see cref="System.Uri"/>.</param>
        /// <param name="refreshToken">The refresh token.</param>
        public AccessToken(string token, int expiresIn, Uri refreshUri, string refreshToken)
            : this(token, DateTime.UtcNow.AddSeconds(expiresIn), refreshUri, refreshToken)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="AccessToken"/> struct.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="expires">The <see cref="System.DateTime"/> the <paramref name="token"/> expires.</param>
        /// <param name="refreshUri">The refresh <see cref="System.Uri"/>.</param>
        /// <param name="refreshToken">The refresh token.</param>
        public AccessToken(string token, DateTime expires, Uri refreshUri, string refreshToken)
            : this()
        {
            this.Token = token;
            this.Expires = expires;
            this.RefreshUri = refreshUri;
            this.RefreshToken = refreshToken;
        }

        /// <summary>
        /// Gets the authentication information for OAuth authentication with the API.
        /// </summary>
        public string Token { get; private set; }

        /// <summary>
        /// Gets the <see cref="System.DateTime"/> the <see cref="M:Token"/> expires.
        /// </summary>
        public DateTime Expires { get; private set; }

        /// <summary>
        /// Gets the <see cref="System.Uri"/> to follow to refresh this <see cref="AccessToken"/>.
        /// </summary>
        public Uri RefreshUri { get; private set; }

        /// <summary>
        /// Gets the authentication information to use to update the <see cref="AccessToken"/>.
        /// </summary>
        public string RefreshToken { get; private set; }
    }
}