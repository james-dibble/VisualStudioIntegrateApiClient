namespace VisualStudioIntegreate.Configuration
{
    using System;
    using System.Configuration;

    using VisualStudioIntegreate.Client;

    /// <summary>
    /// A configuration section to use to define applicaiton credentials in configuration files.
    /// </summary>
    public class VisualStudioIntegrateApplicationConfigurationSection : ConfigurationSection
    {
        /// <summary>
        /// Gets the application ID.
        /// </summary>
        [ConfigurationProperty("applicationId", IsRequired = true)]
        public string ApplicationId
        {
            get { return this["applicationId"].ToString(); }
        }

        /// <summary>
        /// Gets the secret token for the application.
        /// </summary>
        [ConfigurationProperty("applicationSecret", IsRequired = true)]
        public string ApplicationSecret
        {
            get { return this["applicationSecret"].ToString(); }
        }

        /// <summary>
        /// Gets the <see cref="System.Uri"/> to follow to get an authorization token.
        /// </summary>
        [ConfigurationProperty("authorizeUrl", IsRequired = true)]
        public Uri AuthorizeUrl
        {
            get { return new Uri(this["authorizeUrl"].ToString()); }
        }

        /// <summary>
        /// Gets the <see cref="System.Uri"/> to follow to get an access token.
        /// </summary>
        [ConfigurationProperty("accessTokenUrl", IsRequired = true)]
        public Uri AccessTokenUrl
        {
            get { return new Uri(this["accessTokenUrl"].ToString()); }
        }

        /// <summary>
        /// Gets the <see cref="System.Uri"/> for the authorization process
        /// to return to with an authorization code.
        /// </summary>
        [ConfigurationProperty("callbackUri", IsRequired = true)]
        public Uri CallbackUri
        {
            get { return new Uri(this["callbackUri"].ToString()); }
        }

        /// <summary>
        /// Gets the scopes for authorization.
        /// </summary>
        [ConfigurationProperty("authorizedScopes", IsRequired = true)]
        public string AuthorizedScopes
        {
            get { return this["authorizedScopes"].ToString(); }
        }

        /// <summary>
        /// Parse the configuration section and create an object holding the parent applicaitons credentials.
        /// </summary>
        /// <returns>The configuration section and create an object holding the parent applicaitons credentials.</returns>
        public ConsumerApplication GetApplicationCredentials()
        {
            var application = new ConsumerApplication
            {
                AccessTokenUrl = this.AccessTokenUrl,
                ApplicationId = this.ApplicationId,
                ApplicationSecret = this.ApplicationSecret,
                AuthorizeUrl = this.AuthorizeUrl,
                AuthorizedScopes = this.AuthorizedScopes.Split(' '),
                CallbackUri = this.CallbackUri
            };

            return application;
        }
    }
}