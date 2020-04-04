using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;

namespace web
{
    public class SeedFactory
    {
        public static void Initialize(Context context)
        {
            context.Database.EnsureCreated();
            if (!context.Set<Technology>().Any())
            {
                var technologies = new List<Technology>()
                {
                    new Technology
                    {
                        Name = "JavaScript",
                        Description = "Magical bag of hidden bugs",
                        TechnologyType = TechnologyType.Frontend
                    },
                    new Technology
                    {
                        Name = "CSS",
                        Description = "Styling language for the web",
                        TechnologyType = TechnologyType.Frontend
                    },
                    new Technology
                    {
                        Name = "Bootstrap",
                        Description = "CSS Library",
                        TechnologyType = TechnologyType.Frontend
                    },
                    new Technology
                    {
                        Name = "JQuery",
                        Description = "Javascript Framework",
                        TechnologyType = TechnologyType.Frontend
                    },
                    new Technology
                    {
                        Name = "HTML",
                        Description = "Hypertext Markup Language",
                        TechnologyType = TechnologyType.Frontend
                    },       new Technology
                    {
                        Name = "HTML",
                        Description = "Hypertext Markup Language",
                        TechnologyType = TechnologyType.Frontend
                    },
                    new Technology
                    {
                        Name = "C#",
                        Description = "Object Oriented Programming Language",
                        TechnologyType = TechnologyType.Backend
                    },
                    new Technology
                    {
                        Name = ".NET",
                        Description = "Hypertext Markup Language",
                        TechnologyType = TechnologyType.Backend
                    },
                    new Technology
                    {
                        Name = "MVC",
                        Description = "Common Architecture Pattern",
                        TechnologyType = TechnologyType.Backend
                    },
                    new Technology
                    {
                        Name = "Azure",
                        Description = "Cloud Provider",
                        TechnologyType = TechnologyType.Backend
                    },
                    new Technology
                    {
                        Name = "SQL",
                        Description = "Structured Query Language",
                        TechnologyType = TechnologyType.Database
                    }
                };
                context.AddRangeAsync(technologies);
                context.SaveChangesAsync();
            }
        }
    }
}