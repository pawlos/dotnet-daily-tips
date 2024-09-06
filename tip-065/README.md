# 065 - Interceptors #

One of the latest concepts added to Entity Framework is interceptors. What they offer for developers is the ability to modify the database command before it is sent to the database.

Interceptors can define several methods, and at each level, we can make specific modifications.
On the `DbCommandInterceptor`, the list of methods is quite long:

- 📌 `CommandCreating`, `CommandCreated`, `CommandInitialized`, `CommandCanceled`, `CommandCanceledAsync`, `CommandFailed`, `CommandFailedAsync`
- 📌 `ReaderExecuting`, `ReaderExecutingAsync`, `ScalarExecutingAsync`
- 📌 `ScalarExecuting`, `ScalarExecuted`, `ScalarExecutedAsync`
- 📌 `NonQueryExecuting`, `NonQueryExecutingAsync`, `NonQueryExecuted`
- 📌 `ReaderExecuted`, `ReaderExecutedAsync`
- 📌 `DataReaderClosing`, `DataReaderClosingAsync`, `DataReaderDisposing`

All the methods are virtual, so we can override only the ones we are interested in. Additionally, there's an `ISaveChangesInterceptor` that allows us to control `SaveChanges` methods.

Have you been using interceptors in your projects?

Docs 📑: https://learn.microsoft.com/en-us/ef/core/logging-events-diagnostics/interceptors

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    // ✅ Add interceptors
    optionsBuilder.AddInterceptors(new SaveChangesInterceptor());
    base.OnConfiguring(optionsBuilder);
}
```