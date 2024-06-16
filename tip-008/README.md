# 008 - Log injection #

Github Advanced Security scans the code and can show us the potential vulnerability information.

One of those is [cs/log-forging](https://codeql.github.com/codeql-query-help/csharp/cs-log-forging/). This is a situation when log entries are based on user input. If our endpoint parameter is string and that parameter goes straight to the log, an attacker can forge entries in our log file. That could give us false information that something had happened. Since very often we use logs as a source of what happens in our system, we don't want that to occur.

We can fix this issue by replacing new lines in our input parameter by either using `string.Replace` method, or with `string.ReplaceLineEnding(string.Empty)` for example.

The vulnerable method could like like this:
```csharp
app.MapGet("/vulnerable-endpoint", (string[] items, ILoggerFactory loggerFactory) =>
{
    var logger = loggerFactory.CreateLogger("endpoint");
    logger.Log(LogLevel.Information, "Calling with items: {}", items);
});
```

And the same method with a fix:
```csharp
app.MapGet("/vulnerable-endpoint", (string[] items, ILoggerFactory loggerFactory) =>
{
    var logger = loggerFactory.CreateLogger("endpoint");
    logger.Log(LogLevel.Information, "Calling with items: {}", items.Select(x => x.ReplaceLineEndings(string.Empty));
});
```