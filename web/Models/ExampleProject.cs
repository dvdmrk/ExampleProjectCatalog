using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class ExampleProject : BaseEntity
    {
        public string RepositoryName {get;set;}
        /// <summary>
        /// This is a one-to-many relationship with Student
        /// <summary>
        public Guid StudentId {get;set;}
        public Student Student {get;set;}
        /// <summary>
        /// This is a many-to-many relationship between Example Projects and Technologies        /// <summary>
        public ExampleProjectTechnology ExampleProjectTechnologies {get;set;}
        public ICollection<Technology> Technologies {get;set;}
        public int Grade {get;set;}
        /// <summary>
        /// This is a one-to-many relationship with Milestones
        /// <summary>
        public ICollection<Milestone> MileStones {get;set;}
    }
}