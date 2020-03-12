# Week 3

## Requirements:

Create a Code-First Database using Entity Framework.

## Expectation:

In this tutorial you will configure any One-to-One relationships and any Many-to-Many relationships using fluent API. By the end of this tutorial you will have created your first Database migration resulting in a new Database. You will also be able to access this Database using SQL Server Management Studio. 

---

## Exercise - ?

## Getting Started

1. Add the following nuget packages to the web project using the cli:

   - dotnet add package Microsoft.EntityFrameworkCore
   - dotnet add package Microsoft.EntityFrameworkCore.Design
   - dotnet add package Microsoft.EntityFrameworkCore.SqlServer

2. Install the Entity Framework dotnet CLI tools with the following command:

   - dotnet tool install --global dotnet-ef

3. Create a folder named Data within the web project.

4. Create a Context class in the Data folder.

The context class should inherit from DbContext. This class requires a constructor 

6. Add connection string to appsettings.json:

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=Context;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
```

7. Add the dependency injection to the ConfigureServices method of the Startup class.

```csharp
services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
```



8. Push your project to GitHub:

```
git add .
git commit -m "Added models"
git push -u origin Week4
```

---

## Example Project Reference

In the [Example Project Data Folder](../../tree/Week4/web/Data):