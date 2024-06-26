# 014 - Validation in Wolverine #

Validating the data before pushing it further down our system is crucial even if we are not vulnerable to any injection🙂. Wolverine supports Fluent Validation or we can use `Before` method in our handler to validate the event before we handle it.

Enable FluentValidation:
```csharp
using Wolverine.FluentValidation;

builder.Host.UseWolverine(options =>
{
    // enable FluentValidation
    options.UseFluentValidation();
    // ...
    options.Discovery.IncludeAssembly(typeof(MarkerHandler).Assembly);
});
```

Use `Before` method in the handler. If we detect the problem we can return `ProblemDetails`. See [Tip-012](../tip-012/README.md).

```csharp
public class NewParcelHandler(
    IParcelsStore parcelsStore,
    ITrackingNumberGenerator trackingNumberGenerator)
{
    public ProblemDetails Before(NewShipmentCommand newShipmentCommand)
    {
        if (newShipmentCommand.Sender is {Name.Length: >5 })
        {
            return WolverineContinue.NoProblems;
        }

        return new ProblemDetails(/* return problem details */);
    }

    public Result<NewShipmentResult> Handle(NewShipmentCommand newShipmentCommand)
    {

    }
}
```