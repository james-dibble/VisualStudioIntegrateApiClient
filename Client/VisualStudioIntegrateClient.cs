namespace VisualStudioIntegreate.Client
{
    /// <summary>
    /// A default implementation of the <see cref="IVisualStudioIntegrateClient"/> interface.
    /// </summary>
    public class VisualStudioIntegrateClient : IVisualStudioIntegrateClient
    {
        private readonly ConsumerApplication _consumerApplication;

        /// <summary>
        /// Create a new instance of the <see cref="VisualStudioIntegrateClient"/> class.
        /// </summary>
        /// <param name="applicationIdentity">The consumer application information.</param>
        public VisualStudioIntegrateClient(ConsumerApplication applicationIdentity)
        {
            this._consumerApplication = applicationIdentity;
        }
    }
}