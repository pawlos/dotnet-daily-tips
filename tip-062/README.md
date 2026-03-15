# 062 - EF.Functions.Collate #

One of the functions that was mentioned in yesterday's post was `EF.Functions.Collate`, and collation is the thing that might cause issues when combining the DB and .NET code.

You might set collation on the DB so that upper and lower case letters will be treated the same - no distinctions. String equality, on the other hand, does recognize lower and upper characters. So if we combine the two, we get into trouble.

Let's assume that we have a simple table with a varchar column and a unique constraint on it with a collation that doesn't differentiate between lower and upper case. Now, we have the following code that loads data into memory and checks if an entry exists before adding it. Our comparison will be fruitless, but adding to the database will fail with an exception.

See the extra code below 👇

Docs 📑: https://learn.microsoft.com/en-us/ef/core/miscellaneous/collations-and-case-sensitivity



```csharp
// ✅ we already do have an entry in our DB called .net lesson
var lessons = dbContext.Lessons.ToArray();

// we want to check before we add - this will not yield results as in C# ".net lesson" is not equal to ".NET Lesson"
if (lessons.All(x => x.Title != ".NET Lesson"))
{
    dbContext.Lessons.Add(new Lesson { Title = ".NET Lesson"});

    // DB will throw an exception from unique constraint violation
    await dbContext.SaveChangesAsync();
}
```