# Week 4

## Requirements:

Create a Code-First Database using Entity Framework.

## Expectation:

In this tutorial you will configure any One-to-One relationships and any Many-to-Many relationships using fluent API. By the end of this tutorial you will have created your first Database migration resulting in a new Database. You will also be able to access this Database using SQL Server Management Studio. 

---

## Getting Started

> Start by creating a new branch with the following command: <code>git checkout -b Week4</code>

### Setup

1. Add the following nuget packages to the web project using the cli:

   - dotnet add package Microsoft.EntityFrameworkCore
   - dotnet add package Microsoft.EntityFrameworkCore.Design
   - dotnet add package Microsoft.EntityFrameworkCore.SqlServer

2. Install the Entity Framework dotnet CLI tools with the following command:

   - dotnet tool install --global dotnet-ef

3. Create a folder named Data within the web project.

### Dependency Injection

<details>
<summary>
What is Dependency Injection?
</summary>

I wish more Code Louisvile students would ask me, "what is DI (Dependency Injection)?" Because, it's such a common tool in modern software architecture. Day 1 as a "Green Developer" you're asked to reference a method from another class inside of a class but neither class is static. What kind of sorcery is this? This is the magic of inversion of control. 

> DI is an implementation of the SOLID Principle- Inversion of Control. DI through IoC decouples the creation of an object from it's instantiation. Basically, that just means you don't need to know how an object is created in order to use it.

A real life example of this is: you don't need to know all of the dependencies of a car (engine, battery, flux capacitor), in order to call the method drive.

.NET Core come equipped with a really usable DI Implementation that allows you to configure dependencies in the startup class, and reference their implementation in the constructor of the implementing class. 

Example: 

<code>appsettings.json</code>

```json
"ConnectionStrings": {
   "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ExampleProjectContext;Trusted_Connection=True;MultipleActiveResultSets=true"
},
```

<code>Startup.cs</code>

```csharp
public void ConfigureServices(IServiceCollection services)
{
services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
}
```

<code>Context.cs</code>

```csharp
public class Context : DbContext
{
   public Context(DbContextOptions<Context> options) : base(options) {}
}
```

In the above example we are passing the connection string from our appsettings to the AddDbContext method in our dependency pipeline of the startup class, to the constructor of our context class which passes the ContextOptionsBuilder to the base DbContext class.

 ---

</details>

4. Create a Context class in the Data folder.

The context class should inherit from DbContext and supply the DbContext constructor through it's own constructor implementation.

```csharp
public class Context : DbContext
{
   public Context(DbContextOptions<Context> options) : base(options) {}
}
```

Next register your tables by adding them as a DbSet of the class you want a table to be created for.

```csharp
using Microsoft.EntityFrameworkCore;
using web.Models;

namespace web.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        //Configure Technology and ExampleProject Foreign Keys for the ExampleProjectTechnology Table 
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<ExampleProjectTechnology>().HasKey(t => new { t.TechnologyId, t.ExampleProjectId });
        }
        //Register Students table
        DbSet<Student> Students { get; set; }
        //Register Technologies table
        DbSet<Technology> Technologies { get; set; }
        //Register Milestones table
        DbSet<Milestone> Milestones { get; set; }
        //Register ExampleProjects table
        DbSet<ExampleProject> ExampleProjects { get; set; }
    }
}
```

If you've used the <code>[ForeignKey()]</code> Data Annotation and aren't configuring any Many-to-Many relationships, you won't need to override the OnModelCreating method. If you have any questions, read through this article: [EF Core Relationships](https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key).

5. Add connection string to appsettings.json:

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=[ExampleProjectContext];Trusted_Connection=True;MultipleActiveResultSets=true"
  },
```

Replace everything in the square brackets with what you would like your database to be named. I'm chosing to name mine ExampleProjectContext. The only consideration to remember is that, for this project the db name should be unique to this project. You can change this value at any point to create a new database. This value will be loaded by the ConfigureServices method in the Startup class.  

> (localdb)\MSSQLLocalDB can be connected to via Sql Server Management Studio. 

6. Add the dependency injection to the ConfigureServices method of the Startup class.

```csharp
services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
```

Adding the Context class to your services pipeline allows you to reference the the DbSet properties defined therein. Later, this will allow you to pull data from the database for storage or passing to the view.

### Scaffolding a Code First Database

7. Create an Initial Database Migration

Run the following command from the web folder: <code>dotnet ef migrations add InitialMigration</code>. This will create files for generating your Database. The more databases you create, the more familliar you will be with ensuring it's creating the right tables and relationships. 

> Entity Framework is trying to understand what SQL to write to generate your database. Errors aren't uncommon, they are an indication that your relationships aren't configured appropriately. If you get an error, that's not uncommon. Read the error, if it makes sense fix it. If it doesn't make sense, google it. If it still doesn't make sense

8. Apply your Migration to your Database

From within the web folder, run the following command to apply your generated migration to your database: <code>dotnet ef database update</code>.

At this point you can now go into SSMS (SQL Server Management Studio) to confirm that your database tables and relationshps have been configured correctly. 

> (localdb)\MSSQLLocalDB can be connected to via Sql Server Management Studio. 

### Wrapping Up

Push your project to GitHub:

```
git add .
git commit -m "Scaffoled InitialMigration and UpdatedDatabase"
git push -u origin Week4
```