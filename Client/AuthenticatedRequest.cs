namespace VisualStudioIntegreate.Client
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// A wrapper class for <see cref="Request"/>s that require an identity for complete.
    /// </summary>
    public class AuthenticatedRequest : Request
    {
    }

    /// <summary>
    /// A wrapper class for <see cref="Request"/>s that require an identity for complete.
    /// </summary>
    /// <typeparam name="T">The type of object contained in the response of the <see cref="Request"/>.</typeparam>
    [SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Generic version of class is fine.")]
    public class AuthenticatedRequest<T> : AuthenticatedRequest
    {
    }
}