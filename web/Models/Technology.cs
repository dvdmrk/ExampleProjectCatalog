using System.Collections.Generic;
namespace web.Models
{
    public class Technology : BaseEntity
    {
        public string Description {get;set;}
        public TechnologyType TechnologyType {get;set;}
        /// <summary>
        /// This is a many-to-many relationship between ExampleProjects and Technologies
        /// <summary>
        public ICollection<ExampleProjectTechnology> ExampleProjectTechnologies {get;set;}
    }
}