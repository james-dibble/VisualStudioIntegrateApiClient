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
        public string ApplicationId { get; set; }

        public string ApplicationSecret { get; set; }

        public Uri AuthorizeUrl { get; set; }

        public Uri AccessTokenUrl { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="System.Uri"/> for the authorzation process
        /// to return to with an authorization code.
        /// </summary>
        public Uri CallbackUri { get; set; }

        public IEnumerable<string> AuthorizedScopes { get; set; }
    }
}