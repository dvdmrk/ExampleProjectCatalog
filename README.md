# Week 3

## Requirements:

By the end of this tutorial you will have at least 1 class representing all or some of that data you will be performing CRUD operations on (you can add to these later).

## Expectation:

Populate the models folder of your MVC application with any classes required to generate your database and any required relationships (you should work with your mentor/ mentors to determine the data you will be modeling).

---

## Exercise - Modeling Data

We will be using the classes created in this tutorial to scaffold our database from a code first approach. That means we're going to write code that defines our database schema. To put it simply:

- Each class will be table.
- Each field on a class will be a column in that table.
- Each new entry in the database will be a row in that table.

Thinking about your idea, what objects does it rely on? For the next few exercises we are going to model Car data. This might be useful if we run a website that lists cars and car information. For this example, 'Car' would be our class and fields like Make, Model and Year would be our fields. Our Car class with the Make property would look like the following:

```csharp
namespace web.Models
{
    public class Car
    {
        public string Make { get; set; }
    }
}
```

In this example we are defining Make as a string. However, Make could also be its own class defined like this:

```csharp
public Make Make { get; set; }
```

We can also define fields of other simple and complex propery types. A simple type would be: int, bool, double, etc- and a complex type would be another class or Collection of a Class.

### Modeling Fields

Challenge

<code>Model the data for a Car class with the fields: Make, Model, Year, and MPH (Miles per Hour).</code>

<details>
<summary>Answer</summary>

```csharp
namespace web.Models
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }   
        public int Year { get; set; }
        public double MPG { get; set; }
    }
}
```

</details>

### Modeling Complex Fields

Challenge

<code>Create another class for an Engine, and add it as a field on the Car class.</code>

<details>
<summary>Answer</summary>

```csharp
namespace web.Models
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }   
        public int Year { get; set; }
        public double MPG { get; set; }
        public Engine Engine { get; set; }
    }

    public class Engine
    {
    }
}
```

</details>

> #### When modeling relationships to generate a database with Entity Framework Core, you have to be more specific about the relationship and how the database should be created. [Entity Framework Relationships Documentation](https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key)

## Exercise - Modeling Relationships

After reviewing the above documentation, there are a few additional rules to follow for modeling our Classes to scaffold our database.

- One-to-One
  - We need to add an index for the related object.

```csharp
public Guid MakeId { get; set; }
public Make Make { get; set; }
```

- One-to-Many
   - We need to define the relationship as a collection on one side, and a complex object with an index on the other side.
   - Imagine if an ower had a collection of cars:

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class Base
    {
        [Key]
        public Guid Id { get; set; }
    }
    public class Owner : Base
    {
        public ICollection<Car> Cars { get; set; }
    }
    public class Car : Base
    {
        public Guid OwnerId { get; set; }
        public Owner Owner { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }   
        public int Year { get; set; }
        public double MPG { get; set; }
    }
}
```

- Many-to-Many
   - We need to define a bridge table that explicitly references both objects and their index properties, and the relating classes need to have a collection of their related objects.

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class Base
    {
        [Key]
        public Guid Id { get; set; }
    }
    public class Car : Base
    {
        public string Make { get; set; }
        public string Model { get; set; }   
        public int Year { get; set; }
        public double MPG { get; set; }
        public ICollection<Engine> Engine { get; set;}
    }
    public class Engine : Base 
    {
        public ICollection<Car> Cars { get; set; }
    }
    public class CareEngines 
    {
        public Guid CarId { get; set; }
        public Car Car { get; set; }
        public Guid EngineId { get; set; }
        public Engine Engine { get; set; }
    }
}
```

---

## Getting Started

1. Create a new branch for your current repository:

<code>git checkout -b Week3</code>

2. Create at least 1 new class in the models folder of your MVC Project to represent a table/ tables in your database.

![alt text](./resources/new-class.jpg "Create a new class")

3. Create the fields on this new class/ classes which will represent the columns in the table/ tables.

Review the examples above fro clarification and discuss with mentor/ mentors to determine fields.

4. Configure any required relationships.

Review the examples above for clarification and discuss with mentor/ mentors to determine relationships.

5. Push your project to GitHub:

```
git add .
git commit -m "Added models"
git push -u origin Week3
```