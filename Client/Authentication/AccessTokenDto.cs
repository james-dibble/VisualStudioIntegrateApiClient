namespace VisualStudioIntegreate.Client.Authentication
{
    /// <summary>
    /// An object to create an <see cref="AccessToken"/> from.
    /// </summary>
    public class AccessTokenDto
    {
        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the token type.
        /// </summary>
        public string TokenType { get; set; }

        /// <summary>
        /// Gets or sets the number of seconds until the token expires.
        /// </summary>
        public int ExpiresIn { get; set; }

        /// <summary>
        /// Gets or sets the refresh token.
        /// </summary>
        public string RefreshToken { get; set; }
    }
}