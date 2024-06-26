# 011 - Switch expressions #

Have you switched (😉) to switch-expression from the old style if statements?

Switch expressions are not considered new thing (were introduced in C# 8) but they are constantly being extended with new ways to define arms of the switch expression. We were able to use that in one of the recent live streams to simplify some code that handle `Result<T>` being returned.

From bulky if statement, through switch expression based on boolean value to the form that fully utilized the power of switch expressions where we already unpack the value that we want to use.

Old way using if-statement:
```csharp
var delivery = parcelsStore.GetByTrackingId(new TrackingId(query.Id));
if (!delivery.IsSuccessful)
{
    return "Delivery not found";
}

return new ParcelDetailsResult(delivery.Value.Sender,
            delivery.Value.Recipient,
            new ShipmentBasicInfo(delivery.Value.TrackingId));
```

Using switch expression on a boolean property
```csharp
var delivery = parcelsStore.GetByTrackingId(new TrackingId(query.Id));
return delivery.IsSuccessful switch
{
    true =>
        new ParcelDetailsResult(delivery.Value.Sender,
            delivery.Value.Recipient,
            new ShipmentBasicInfo(delivery.Value.TrackingId)),
    _ => "Delivery not found",
};
```

Fully utilizing switch expressions
```csharp
var delivery = parcelsStore.GetByTrackingId(new TrackingId(query.Id));
return delivery switch
{
    { Value: { } value } =>
        new ParcelDetailsResult(value.Sender,
            value.Recipient,
            new ShipmentBasicInfo(value.TrackingId)),
    _ => "Delivery not found",
}
```


Link to the docs: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/switch-expression