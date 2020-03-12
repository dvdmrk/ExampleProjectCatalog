using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models
{
    /// <summary>
    /// This is a many-to-many relationship between Example Projects and Technologies
    /// <summary>
    public class ExampleProjectTechnology
    {
        public Guid ExampleProjectId { get; set; }
        public Guid TechnologyId { get; set; }
        [ForeignKey("ExampleProjectId")]
        public ExampleProject ExampleProject { get; set; }
        [ForeignKey("TechnologyId")]
        public Technology Technology { get; set; }
    }
}