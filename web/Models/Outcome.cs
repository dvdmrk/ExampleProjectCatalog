using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models
{
    public class Outcome : BaseEntity
    {
        public int Grade { get; set; }
        public Guid ExampleProjectId { get; set; }
        /// <summary>
        /// This is a one-to-one relationship with ExampleProject
        /// <summary>
        [ForeignKey("ExampleProjectId")]
        public ExampleProject ExampleProject { get; set; }
    }
}