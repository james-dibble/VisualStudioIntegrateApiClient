namespace VisualStudioIntegreate.Client
{
    using System;

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

        public string AuthorizedScopes { get; set; }
    }
}