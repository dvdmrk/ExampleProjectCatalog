using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace web.Models
{
    public class ExampleProject : BaseNamedEntity
    {
        public ExampleProject(){}
        public ExampleProject(ExampleProjectViewModel exampleProject)
        {
            StudentId = exampleProject.StudentId;
            Outcome = new Outcome();
            ExampleProjectTechnologies = exampleProject.TechnologyIds.Select(e =>
                new ExampleProjectTechnology
                {
                    TechnologyId = e,
                }).ToList();
        }

        public Guid StudentId { get; set; }
        public Guid OutcomeId { get; set; }
        /// <summary>
        /// This is a one-to-many relationship with Student
        /// <summary>
        public Student Student { get; set; }
        /// <summary>
        /// This is a one-to-one relationship with Outcome
        /// <summary>
        [ForeignKey("OutcomeId")]
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