# 002 - Wolverine - Handlers discovery #

Using Wolverine one needs to remember that by default it scans only the same assembly that it is added to. We stumbled upon this on our last Ostra Piła streaming. 

If our handlers are in a different assembly we need to point Wolverine to that place. We can do it by using `options.Discovery.IncludeAssembly` method and passing the assembly that contains them.

```csharp
builder.Host.UseWolverine(options =>
                          options.Discovery.IncludeAssembly(typeof(MarkerHandler).Assembly));
```