namespace VisualStudioIntegreate.Client.Authentication
{
    using Newtonsoft.Json;

    /// <summary>
    /// An object to create an <see cref="AccessToken"/> from.
    /// </summary>
    public class AccessTokenDto
    {
        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the token type.
        /// </summary>
        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// Gets or sets the number of seconds until the token expires.
        /// </summary>
        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary>
        /// Gets or sets the refresh token.
        /// </summary>
        [JsonProperty(PropertyName = "refresh_token")]
        public string RefreshToken { get; set; }
    }
}