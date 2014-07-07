namespace VisualStudioIntegreate.Client
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// An object that represents information regarding the parent application
    /// that is utilising the VSO REST API.
    /// </summary>
    public class ConsumerApplication
    {
        /// <summary>
        /// Gets or sets the application ID.
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the secret token for the application.
        /// </summary>
        public string ApplicationSecret { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="System.Uri"/> to follow to get an authorization token.
        /// </summary>
        public Uri AuthorizeUrl { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="System.Uri"/> to follow to get an access token.
        /// </summary>
        public Uri AccessTokenUrl { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="System.Uri"/> for the authorization process
        /// to return to with an authorization code.
        /// </summary>
        public Uri CallbackUri { get; set; }

        /// <summary>
        /// Gets or sets the scopes for authorization.
        /// </summary>
        public IEnumerable<string> AuthorizedScopes { get; set; }
    }
}