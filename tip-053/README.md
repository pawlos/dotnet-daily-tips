# 053 - CountBy, AggregateBy #

LINQ is with us for a very long time. It feels like it's the forever and it's a API is stable. But from some time we were given a MinBy & MaxBy method. Now from .NET 9 we will welcome two new methods into the LINQ family.

- 1️⃣ `CountBy` - allows to calculate the count of the groups by key w/o the need of grouping it first
- 2️⃣ `AggregateBy` - is for more generic workflows

Docs 📑: https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-9/overview#linq


```csharp
string sourceText = """Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent neque tellus, tristique eget est lobortis, lobortis aliquet dui. Sed quis dapibus mi. Curabitur commodo sit amet eros quis accumsan.""";

// Find the most frequent word in text
KeyValuePair<string, int> mostFrequentWord = sourceText
    .Split(new[] {' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries)
    .Select(word => word.ToLowerInvariant())
    .CountBy(word => word)
    .MaxBy(pair => pair.Value);
```