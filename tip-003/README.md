# 003 - ctor vs method injection #

We are used to inject via .ctor but Wolverine use a DI container (Lamar) that allows to use static classes with a static method for Handle. In such scenario any dependency will be injected into that method. Which one do you prefer?

Dependency injection in constructor
```csharp
public class NewParcelHandler(ParcelStore parcelsStore)
{
    public Result<NewShipmentResult> Handle(NewShipmentCommand newShipmentCommand)
    {
        // handle the command
    }
}
```

or via method
```csharp
public static class NewParcelhandler
{
    public Result<NewShipmentResult> Handle(NewShipmentCommand newShipmentCommand)
    {
        // handle the command
    }
}
```