# 004 - Wolverine registration rules #

Auto-registering things might cause some undesidered effects when we don't see things happening the way we expect them to do. It might be that our handler is not triggered even though we think we've registered it correctly.
Using Wolverine handlers we can see why the registration did not work and what is being check in order to satisfy the matching logic.

```csharp
public class ParcelByIdHendler(ParcelStore parcelsStore) // typo in Handler
{
    public Result<ParcelDetailsResult> Handle(ParcelByIdQuery query)
    {
        // handle
        return new Result<ParcelDetailsResult>();
    }
}
// Main Program flow
Host.CreateDefaultBuilder()
    .UseWolverine(options =>
    {
        Console.WriteLine(options.DescribeHandlerMatch(typeof(ParcelByIdHendler)));
    }).Build();

// No Wolverine extensions are detected
// MISS -- Name ends with 'Handler'
// MISS -- Name ends with 'Consumer'
// MISS -- Inherits from Wolverine.Saga
// MISS -- Implements Wolverine.IWolverineHandler
// MISS -- Has attribute Wolverine.Attributes.WolverineHandlerAttribute
```