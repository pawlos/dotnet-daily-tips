# 095 - Stopwatch without allocations #

Did you know you can measure time in .NET without allocating a new Stopwatch instance?

Starting with .NET 7, the Stopwatch class provides two static methods that let you track time without any allocations:

- `Stopwatch.GetTimestamp()` – gets the current timestamp (a raw long value from a high-resolution timer)
- `Stopwatch.GetElapsedTime(startTimestamp)` – calculates the elapsed TimeSpan from a previously recorded timestamp

This is a great way to avoid unnecessary allocations in high-performance or allocation-sensitive code.

Here’s how it works:

```csharp
long start = Stopwatch.GetTimestamp();

// some work here...
await Task.Delay(150);

TimeSpan elapsed = Stopwatch.GetElapsedTime(start);
Console.WriteLine($"Elapsed time: {elapsed.TotalMilliseconds} ms");
// Elapsed time: ~150 ms
```

Unlike using a Stopwatch instance:

```csharp
Stopwatch sw = Stopwatch.StartNew();
// allocates Stopwatch object
```

…this method avoids any object creation. You just work with raw long and TimeSpan values.

📑 Docs: [System.Diagnostics.Stopwatch](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch)

Next time you measure execution time in a hot path, consider this allocation-free option!