# 061 - EF.Functions #

Entity Framework provides a convenient abstraction for accessing databases. When combined with LINQ, it offers a robust framework for data access. When executed, LINQ queries are converted into SQL queries based on the code. However, not all expressions written directly in LINQ can be translated into database operations. In such cases, we need to use additional helpers.

EF.Functions offer several common operations that cannot be accessed otherwise.

- 📌 Like: Allows the use of the SQL LIKE operator.
- 📌 Collate: Provides the ability to specify collation for a column.
- 📌 DateDiffHour/Minute/Day/etc.: Enables the use of the DATEDIFF function within LINQ.

Docs 📑: https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbfunctions?view=efcore-8.0

These are just a few examples. It's important to note that these functions may not be compatible if we switch to a different database engine.


```csharp
// ✅ Functions.Like allows to use SQL LIKE operator
var lessons = dbContext.Lessons.Where(x => EF.Functions.Like(x.Title, "%NET%"));
```