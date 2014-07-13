namespace VisualStudioIntegreate.Client.Project
{
    using System;

    /// <summary>
    /// An object containing information about a Team Project.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Gets or sets the ID of this <see cref="Project"/>.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Name of this <see cref="Project"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the API Query <see cref="System.Uri"/> of this <see cref="Project"/>.
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// Gets or sets the Description of this <see cref="Project"/>.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Capabilities of this <see cref="Project"/>.
        /// </summary>
        public ProjectCapabilities Capabilities { get; set; }
    }
}