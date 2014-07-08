namespace VisualStudioIntegreate.Client.Profile
{
    using System;

    /// <summary>
    /// Information about a Visual Studio Online user.
    /// </summary>
    public class Profile
    {
        /// <summary>
        /// Gets or sets the chosen name of this user.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the public ID of this user.
        /// </summary>
        public Guid PublicAlias { get; set; }

        /// <summary>
        /// Gets or sets the email address of this user.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the ID of the last core revision of this user.
        /// </summary>
        public int CoreRevision { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="System.DateTime"/> of the last revision.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the ID of this user.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the revision this information about this user was accurate.
        /// </summary>
        public int Revision { get; set; }     
    }
}