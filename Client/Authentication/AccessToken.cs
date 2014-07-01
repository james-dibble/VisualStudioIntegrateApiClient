namespace VisualStudioIntegreate.Client.Authentication
{
    using System;

    public class AccessToken
    {
        public AccessToken(int expiresIn, Uri refreshUri)
            : this(DateTime.UtcNow.AddSeconds(expiresIn), refreshUri)
        {
        }

        public AccessToken(DateTime expires, Uri refreshUri)
        {
            this.Expires = expires;
            this.RefreshUri = refreshUri;
        }

        public DateTime Expires { get; private set; }

        public Uri RefreshUri { get; private set; }
    }
}