# Week 5

## Requirements:

Scaffold at least one CRUD Controller with Views.

## Expectation:

By the end of this week's exercise you will have functional MVC Web App that can Create, Read, Update, and Delete data 

---

## Exercise - Saving to a database

The code you'll write and generate in this weeks course is all in the vien of getting information into your database. The following is an example of how you would get car data into a database. The code you'll generate will write most of this for you, but often throughout your career you won't be so lucky and you'll have to understand how:

- To create a new instance of an object
- Add that instance to the context
- and Save the context

Here is an example of saving an instance of a Car class to a database.

### Example

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

### Activity

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

4. Add your SeedFactory.cs Initialize method to your Startup.cs Configure method.

Add your Context class with a name of `context` as a paramater of the Configure method in the Startup class.

<code>public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Context context)</code>

Within the body of the Configure method call the static Initialize method from the SeedFactory class (we don't need to instantiate this class because we are calling a static method). 

<code>SeedFactory.Initialize(context);</code>

[Here's a link to my implementation](https://github.com/dvdmrk/ExampleProjectCatalog/blob/Week5/web/Startup.cs#L33)

We added the Context class to our dependency pipeline in Week 4. That makes it available as a paramater in our Configure method. 

5. Scaffold CRUD Controller and Views

In this step we will be using the `aspnet-codegenerator` to create many of our views and controllers. 

> We've already explored 1 way to get data into the database (by seeding it), the second way is by exposing it for manual insertion. This is not required for all of your classes. 

I've seeded my Technologies table, I will be adding CRUD Controllers/ Views for Students and ExampleProjects because I expect these to be updated most often. 

The following command will generate the StudentController and a Student folder in Views folder that contains Create, Delete, Details, Edit, and Index views.

<code>dotnet aspnet-codegenerator controller --model Student --dataContext Context --controllerName StudentController --relativeFolderPath Controllers --useDefaultLayout</code>

Now I'm going to do the same thing with the ExampleProject class, but first let's breakdown the paramaters on the `aspnet-codegenerator`.

1. `controller` - We are telling the cli tool we want to scaffold a Controller.
2. `--model` - We are telling the cli tool to use the following model/ class.
3. `--dataContext` - We are telling the cli tool to use the following context (a class inheriting from DbContext).
4. `--controllerName` - We are naming the scaffolding result (model name + 'Controller' is a convention that helps the default routing locate your cooresponding views).
5. `--relativeFolderPath` - We are telling the cli tool where we want the new controller to be generated, the 'Controllers' folder.
6. `--useDefaultLayout` - We are telling the cli tool to generate views for this controller using the default layout page: `_Layout.cshtml`.

<code>dotnet aspnet-codegenerator controller -m ExampleProject -dc Context -name ExampleProjectController -outDir Controllers -udl</code>

Use the following command to open the help menu in your terminal: `dotnet aspnet-codegenerator controller -h` or [view a full list of aspnet-codegenerator commands](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/tools/dotnet-aspnet-codegenerator?view=aspnetcore-3.1) if you want to learn more.

6. Add your new Controllers to your Layout page

Navigate to Views/Shared/_Layout.cshtml and look around. The important part to be congizant of is: render body. The views you just scaffolded will be rendered in that area when their cooresponding controller/ action route is navigated to in the address bar.

In this example we are adding routes to our new controller/ actions within the main navigation. 

![alt text](resources\layout.jpg "Layout before and after.")

#### Before

This is what your navigation looks like before.

```html
<div class="navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse">
    <ul class="navbar-nav flex-grow-1">
        <li class="nav-item">
            <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Index">Home</a>
        </li>
        <li class="nav-item">
            <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Privacy">Privacy</a>
        </li>
    </ul>
</div>
```

#### After

```html
<div class="navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse">
    <ul class="navbar-nav flex-grow-1">
        <li class="nav-item">
            <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Index">Home</a>
        </li>
        <li class="nav-item">
            <a class="nav-link text-dark" asp-area="" asp-controller="Student" asp-action="Index">Students</a>
        </li>
        <li class="nav-item">
            <a class="nav-link text-dark" asp-area="" asp-controller="ExampleProject" asp-action="Index">Example Projects</a>
        </li>
        <li class="nav-item">
            <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Privacy">Privacy</a>
        </li>
    </ul>
</div>
```

**What's changed?**

- We added 2 new list items to the navigation
- Each new list item has a link with `asp-` properties
   - These are tag helpers we will be using `asp-controller` and `asp-action`.
      - The value of `asp-controller` should be equal to the name of our model on which the controller is based (the name of the controller you scaffolded minus 'Controller').
      - We have the following actions in our newly scaffolded controllers: Create, Delete, Details, Edit, Index. I want the value of `asp-action` to be index because this will show a list view of our Students/ ExampleProjects respectively. 
    - [Read the tag helpers documentation](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/built-in/?view=aspnetcore-3.1)

7. Modify any one-to-many display elements to show the object name instead of identifier



8. Add many-to-many display elements and logic to views/ controllers

### Wrapping Up

Push your project to GitHub:

```
git add .
git commit -m "Scaffoled CRUD Controllers and Views"
git push -u origin Week5
```