﻿namespace VisualStudioIntegreate.Client
{
    using System;
    using VisualStudioIntegreate.Client.Authentication;

    /// <summary>
    /// A default implementation of the <see cref="IVisualStudioIntegrateClient"/> interface.
    /// </summary>
    public class VisualStudioIntegrateClient : IVisualStudioIntegrateClient
    {
        private readonly ConsumerApplication _consumerApplication;
        private readonly Lazy<IAuthenticationClient> _authenticationClientInitializer; 

        /// <summary>
        /// Initialises a new instance of the <see cref="VisualStudioIntegrateClient"/> class.
        /// </summary>
        /// <param name="applicationIdentity">The consumer application information.</param>
        public VisualStudioIntegrateClient(ConsumerApplication applicationIdentity)
        {
            this._consumerApplication = applicationIdentity;
            this._authenticationClientInitializer = new Lazy<IAuthenticationClient>(() => new AuthenticationClient(this._consumerApplication));
        }

        /// <summary>
        /// Gets methods for Authenticating with the VSO REST API using an identity.
        /// </summary>
        public IAuthenticationClient Authentication
        {
            get { return this._authenticationClientInitializer.Value; }
        }
    }
}