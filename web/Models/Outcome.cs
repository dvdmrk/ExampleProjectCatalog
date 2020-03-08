using System;

namespace web.Models
{
    public class Outcome : BaseEntity
    {
        /// <summary>
        /// This is a one-to-one relationship with ExampleProject
        /// <summary>
        public Guid ExampleProjectId { get; set; }
        public ExampleProject ExampleProject { get; set; }
        public int Grade { get; set; }
    }
}