namespace VisualStudioIntegreate.Client
{
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Http;

    /// <summary>
    /// A wrapper class for <see cref="HttpRequestMessage"/>s.
    /// </summary>
    public class Request : HttpRequestMessage
    {
    }

    /// <summary>
    /// A wrapper class for <see cref="HttpRequestMessage"/>s.
    /// </summary>
    /// <typeparam name="T">The type of object contained in the response of the <see cref="Request"/>.</typeparam>
    [SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Generic version of class is fine.")]
    public class Request<T> : Request
    {
    }
}