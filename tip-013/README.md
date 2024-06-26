# 013 - Wolverine functional style #

Using Wolverine, or any other mediator, many of our endpoints will look like the following:

```csharp
app.MapPost("/😡📦", ([FromBody] ParcelReturnCommand parcelReturnRequest, IMessageBus bus) => bus.InvokeAsync(parcelReturnRequest));
```
We get the input and we pass it onto the bus.

Since this is so common, Wolverine adds an extension that simplifies such calls. We can use `MapPostToWolverine` and get rid of the passing event onto the bus ourselves. Small update but simplifies our code a bit.

```csharp
app.MapPostToWolverine<ParcelReturnCommand>("/😡📦");
```
