using System;

namespace web.Models
{
    public class Outcome : BaseEntity
    {
        public int Grade { get; set; }
        public Guid ExampleProjectId { get; set; }
        /// <summary>
        /// This is a one-to-one relationship with ExampleProject
        /// <summary>
        public ExampleProject ExampleProject { get; set; }
    }
}