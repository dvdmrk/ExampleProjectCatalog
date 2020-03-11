using System;

namespace web.Models
{
    /// <summary>
    /// This is a many-to-many relationship between Example Projects and Technologies
    /// <summary>
    public class ExampleProjectTechnology
    {
        public Guid ExampleProjectId { get; set; }
        public Guid TechnologyId { get; set; }
        public ExampleProject ExampleProject { get; set; }
        public Technology Technology { get; set; }
    }
}