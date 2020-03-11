using System;
using System.Collections.Generic;
namespace web.Models
{
    public class ExampleProject : BaseEntity
    {
        public string RepositoryName { get; set; }
        public Guid StudentId { get; set; }
        public Guid OutcomeId { get; set; }
        /// <summary>
        /// This is a one-to-many relationship with Student
        /// <summary>
        public Student Student { get; set; }
        /// <summary>
        /// This is a one-to-one relationship with Outcome
        /// <summary>
        public Outcome Outcome { get; set; }
        /// <summary>
        /// This is a one-to-many relationship with Milestones
        /// <summary>
        public ICollection<Milestone> MileStones { get; set; }
        /// <summary>
        /// This is a many-to-many relationship between Example Projects and Technologies        
        /// <summary>
        public ICollection<ExampleProjectTechnology> ExampleProjectTechnologies { get; set; }
    }
}