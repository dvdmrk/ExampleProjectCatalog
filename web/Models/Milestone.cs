using System;
namespace web.Models
{
    public class Milestone : BaseEntity
    {
        public string Goal {get;set;}
        public string BranchName {get;set;}
        public Guid ExampleProjectId {get;set;}
        /// <summary>
        /// This is a one-to-many relationship with ExampleProject
        /// <summary>
        public ExampleProject ExampleProject {get;set;}
    }
}