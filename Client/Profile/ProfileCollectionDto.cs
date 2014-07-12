namespace VisualStudioIntegreate.Client.Profile
{
    using System.Collections.Generic;

    /// <summary>
    /// A container object returned by the API for Profiles
    /// </summary>
    public class ProfileCollectionDto
    {
        /// <summary>
        /// Gets or sets the collection of <see cref="Profile"/>s returned by the API.
        /// </summary>
        public IEnumerable<Profile> Value { get; set; }  
    }
}