using System.Collections.Generic;

namespace web.Models
{
    public class Student : BaseEntity
    {
        public string GitHubUrl {get;set;}
        /// <summary>
        /// This is a one-to-many relationship with ExampleProjects
        /// <summary>
        public ICollection<ExampleProject> ExampleProject {get;set;}
    }
}