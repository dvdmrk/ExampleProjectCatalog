using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models
{
    public class Technology : BaseNamedEntity
    {
        public string Description {get;set;}
        public TechnologyType TechnologyType {get;set;}
        /// <summary>
        /// This is a many-to-many relationship between ExampleProjects and Technologies
        /// <summary>
        public ICollection<ExampleProjectTechnology> ExampleProjectTechnologies {get;set;}
    }
}