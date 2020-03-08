using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class Technology : BaseEntity
    {
        public string Description {get;set;}
        public TechnologyType TechnologyType {get;set;}
        /// <summary>
        /// This is a many-to-many relationship between ExampleProjects and Technologies
        /// <summary>
        public ExampleProjectTechnology ExampleProjectTechnologies {get;set;}
        public ICollection<ExampleProject> ExampleProjects {get;set;}
    }
}