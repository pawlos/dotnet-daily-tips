# 015 - Code Review #

Today, small remark about a code mistake. Tools like Rider or R# shows that mistake but bare VS does not (IIRC) so I still sometimes see such slip in PR reviews.

LINQ's `OrderBy` followed by another `OrderBy` doesn't sort by first expression and then by the second one. It only will use the second one. If we need more columns in the sorting we need to incorporate `ThenBy`, even multiple times.

```csharp
// ❌ this is not correct
var sorted = data
    .OrderBy(d => d.CreatedOn)
    .OrderBy(d => d.Country)
    .ThenBy(d => d.Region);
```

```csharp
// ✅ do this instead
var sorted = data
    .OrderBy(d => d.CreatedOn)
    .ThenBy(d => d.Country)
    .ThenBy(d => d.Region);
```