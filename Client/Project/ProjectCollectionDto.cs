namespace VisualStudioIntegreate.Client.Project
{
    using System.Collections.Generic;

    /// <summary>
    /// A container object returned by the API for Project
    /// </summary>
    public class ProjectCollectionDto
    {
        /// <summary>
        /// Gets or sets the collection of <see cref="Project"/>s returned by the API.
        /// </summary>
        public IEnumerable<Project> Value { get; set; }  
    }
}