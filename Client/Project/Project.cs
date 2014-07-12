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

        /// <summary>
        /// A class represnenting information about the version control used by a Team Project.
        /// </summary>
        public class VersionControlType
        {
            /// <summary>
            /// Gets or sets the name of the version control type.
            /// </summary>
            public string SourceControlType { get; set; }
        }

        /// <summary>
        /// A class representing information about the capabilites of a Team Project.
        /// </summary>
        public class ProjectCapabilities
        {
            /// <summary>
            /// Gets or sets the type of version control used by the parent Team Project.
            /// </summary>
            public VersionControlType VersionControl { get; set; }
        }
    }
}