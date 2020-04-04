# Week 5

## Requirements:

Scaffold at least one CRUD Controller with Views.

## Expectation:

By the end of this week's exercise you will have functional MVC Web App that can Create, Read, Update, and Delete data 

---

## Getting Started

> Start by creating a new branch with the following command: <code>git checkout -b Week5</code>

### Setup

1. Install packages:

Open a terminal and execute the following command from within the web directory (if you've chosen a name other than web for your web project, execute this command from the folder that contains your .csproj file- it will be added as a package to that file). 

<code>dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design</code>

2. Intall tools

Open a terminal and execute the following command from any directory (this will install the aspnet code generator globally). This is the tool that empowers you to scaffold Controllers and views.

<code>dotnet tool install --global dotnet-aspnet-codegenerator</code>

> This is optional. You might not need seed data. This first step is just about populating some of the tables in your database with data. 

3. Create a Seed Factory

Your seed factory will be responsible for loading data into your database. You will do this by creating new instances of the objects you want your database to be populated with. You'll then add those objects to your your context and you'll call the save changes method.

> The following block of code has been outlined with comments to describe what each line is doing.

At a high level this is what the following code does:

- Ensure the Database is created
- Check to see if there is data of the given type
- If there is no data create some data
- When all of the data is created add it to the database
- When all the data is added save the database

### Example

```csharp
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
            // This line ensures your database exists.
            context.Database.EnsureCreated();
            // If the class inside of the Set<> doesn't have any data, the following code will execute.
            if (!context.Set<Technology>().Any())
            {
                // Create a new list of technologies (we'll be saving this later).
                var technologies = new List<Technology>()
                {
                    // Create a new technology specifying all properties except the Id which will be auto generated.
                    new Technology
                    {
                        Name = "JavaScript",
                        Description = "Magical bag of hidden bugs",
                        // TechnologyType is an Enum, that means it has a string value, but it's saved as an int. 
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
                // Add technology list as a change to be saved in the database.
                context.AddRangeAsync(technologies);
                // Save any changes to the database.
                context.SaveChangesAsync();
            }
        }
    }
}
```

### Example

Your version might be more simple such as adding a single car to a cars database.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using web.Data;

namespace web
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) {}
        public DbSet<Car> Cars { get; set; }
    }
    public class Car 
    {
        public Guid Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }
    public class SeedFactory
    {
        public static void Initialize(Context context)
        {
            context.Database.EnsureCreated();
            if (!context.Set<Car>().Any())
            {
                var cars = new List<Car>()
                {
                    new Car
                    {
                        Make = "Hyundai",
                        Model = "Elantra",
                        Year = 2018
                    }
                }
                context.AddRangeAsync(cars);
                context.SaveChangesAsync();
            }
        }
    }
}
```
### Exercise

<details><summary>How would you add 2 cars to the database?</summary>


```csharp
if (!context.Set<Car>().Any())
{
    var cars = new List<Car>()
    {
        new Car
        {
            Make = "Hyundai",
            Model = "Elantra",
            Year = 2018
        },
        new Car
        {
            Make = "Hyundai",
            Model = "Accent",
            Year = 2016
        }
    }
    context.AddRangeAsync(cars);
    context.SaveChangesAsync();
}
```

</details>

4. Add your SeedFactory.cs Initialize method to your Startup.cs Configure method.

Add your Context class with a name of `context` as a paramater of the Configure method in the Startup class.

<code>public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Context context)</code>

Within the body of the Configure method call the static Initialize method from the SeedFactory class (we don't need to instantiate this class because we are calling a static method). 

<code>SeedFactory.Initialize(context);</code>

[Here's a link to my implementation](https://github.com/dvdmrk/ExampleProjectCatalog/blob/Week5/web/Startup.cs#L33)

We added the Context class to our dependency pipeline in Week 4. That makes it available as a paramater in our Configure method. 

5. Scaffold CRUD Controller and Views

<code>dotnet aspnet-codegenerator controller --model Student --dataContext Context --controllerName StudentController --relativeFolderPath Controllers --useDefaultLayout</code>

<code>dotnet aspnet-codegenerator controller --model ExampleProject --dataContext Context --controllerName ExampleProjectController --relativeFolderPath Controllers --useDefaultLayout</code>

### Wrapping Up

Push your project to GitHub:

```
git add .
git commit -m "Scaffoled CRUD Controllers and Views"
git push -u origin Week5
```