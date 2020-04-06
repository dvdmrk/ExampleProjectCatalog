using System;

namespace web.Models
{
    public class ExampleProjectViewModel : BaseNamedEntity
    {
        public Guid StudentId { get; set; }
        public Guid[] TechnologyIds {get;set;}
    }
}