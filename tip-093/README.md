# 093 - AsyncLocal<T> #

Do you know about the `ThreadLocal<T>` type that allows you to declare data storage associated with a specific thread?

If you know that, do you know about a similar concept but for async methods? `AsyncLocal<T>` lets you bind a value to a specific asynchronous flow.
If an async method continues on a different thread, `ThreadLocal<T>` would not work in such a scenario. That's why `AsyncLocal<T>` is used.

Check out the example to see how it works!

Docs 📑: [System.Threading.AsyncLocal](https://learn.microsoft.com/en-us/dotnet/api/system.threading.asynclocal-1?view=net-8.0)

```csharp
AsyncLocal<string> asyncLocalContext = new();

asyncLocalContext.Value = "Value1";
var t1 = Method1("First call");
asyncLocalContext.Value = "Value2";
var t2 = Method1("Second call");

await Task.WhenAll(t1, t2);
return;

async Task Method1(string val)
{
    Console.WriteLine($"Value before: {val}, {asyncLocalContext.Value}");
    await Task.Delay(100);
    Console.WriteLine($"Value after: {val}, {asyncLocalContext.Value}");
}

// This will produce the following output:
//
// Value before: First call, Value1
// Value before: Second call, Value2
// Value after: Second call, Value2
// Value after: First call, Value1
```