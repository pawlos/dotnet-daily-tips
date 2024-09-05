# 064 - `.AsSplitQuery()`/`.AsSingleQuery()` #

Entity Framework, in its default mode, generates a query that is a single statement. Related data sources are linked using the JOIN keyword. However, sometimes this might produce an unwanted effect. Cartesian explosion is a situation where, for example, having A elements of one entity, B elements of another entity, and C elements of a third one, the resulting output contains AxBxC elements. It can grow quickly even with a small input set.

For that reason, a quite recent version of EF introduced extension methods `.AsSplitQuery()` and `.AsSingleQuery()`. With these methods, we can control whether we want to opt-in to generating one query or multiple.

One can enable split query on an individual level or globally by using `UseQuerySplittingBehavior` 👇

Have you tried EF split mode already? Feel free to comment.

Docs 📑: https://learn.microsoft.com/en-us/ef/core/querying/single-split-queries

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    // ℹ use the split query for all queries
    optionsBuilder.UseSQlServer(o =>
        o.UseQuerySplittingBehavior(QuerySplitBehavior.SplitQuery));
    base.OnConfiguring(optionsBuilder);
}
```