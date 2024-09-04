# 063 - EF logging & TagWith() #

With Entity Framework, we do not need to worry about the QUERY that is generated, but sometimes we might want to actually know what query is generated and sent to the database. One can achieve that by using the .LogTo method, which accepts an action that will receive the generated query. For testing purposes, we can just use Console.WriteLine:

```
optionsBuilder.LogTo(Console.WriteLine);
```

But in a big application that might result in a lot of queries generated so how to match query written in code with the one generated?

However, in a large application, this might result in a lot of queries being generated. So how do we match the query written in code with the one generated?

The `TagWith()` method allows us to add this extra bit of information that will help us link the code with the generated query. See the example below: 👇

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    // ...
    optionsBuilder.LogTo(Console.WriteLine); // 👈 add this for logging to console
    base.OnConfiguring(optionsBuilder);
}

// 1️⃣ without any extra info query will be generated but might get los (an log of info severity is generated)
dbContext.Lessons.FirstOrDefault(x => x.Title != ".NET Lessons");

/*
SELECT TOP(1) [l].[Id], [l].[Title]
FROM [Lessons] [l]
WHERE [l].[Title] <> N'.NET Lessons'
*/

// 2️⃣ Add TagWith() to add extra info to the output
dbContext.Lessons.TagWith("Query for investigation").FirstOrDefault(x => x.Title != ".NET Lessons");

/*
-- Query for investigation

SELECT TOP(1) [l].[Id], [l].[Title]
FROM [Lessons] [l]
WHERE [l].[Title] <> N'.NET Lessons'
*/
```