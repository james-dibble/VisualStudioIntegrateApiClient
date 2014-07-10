namespace VisualStudioIntegreate.Client
{
    using System;

    using VisualStudioIntegreate.Client.Authentication;
    using VisualStudioIntegreate.Client.Profile;

    /// <summary>
    /// A default implementation of the <see cref="IVisualStudioIntegrateClient"/> interface.
    /// </summary>
    public class VisualStudioIntegrateClient : IVisualStudioIntegrateClient
    {
        private readonly ConsumerApplication _consumerApplication;
        private readonly Lazy<IAuthenticationClient> _authenticationClientInitializer;
        private readonly Lazy<IProfileClient> _profileClientInitializer; 

        /// <summary>
        /// Initialises a new instance of the <see cref="VisualStudioIntegrateClient"/> class.
        /// </summary>
        /// <param name="applicationIdentity">The consumer application information.</param>
        public VisualStudioIntegrateClient(ConsumerApplication applicationIdentity)
        {
            Guard.IsNotNull(applicationIdentity, "applicationIdentity", "A VisualStudioIntegrateClient must have an application idenity to relay to the API.");

            this._consumerApplication = applicationIdentity;

            this._authenticationClientInitializer = new Lazy<IAuthenticationClient>(() => new AuthenticationClient(this._consumerApplication));
            this._profileClientInitializer = new Lazy<IProfileClient>(() => new ProfileClient());
        }

        /// <summary>
        /// Gets methods for Authenticating with the VSO REST API using an identity.
        /// </summary>
        public IAuthenticationClient Authentication
        {
            get { return this._authenticationClientInitializer.Value; }
        }

        /// <summary>
        /// Gets methods for retrieving profile information.
        /// </summary>
        public IProfileClient Profile
        {
            get { return this._profileClientInitializer.Value; }
        }
    }
}