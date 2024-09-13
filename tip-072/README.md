# 072 - TimeProvider #

Dependency on date & time is one of those things that can break tests, making them non-deterministic if we are not careful enough. Until quite recently, one would have to create their own abstractions for that. From .NET 8, we now have TimeProvider and derived from that `FakeTimeProvider` (from `Microsoft.Extensions.TimeProvider.Testing`). If we need to read the time, we can use that instead of creating a custom one.

`FakeTimeProvider` contains a few interesting methods that allow us to control the time. We can update the original time with the `.Advance` method, or we can use `AutoAdvanceAmount`, which will be used to adjust the time every time we read from it.

Docs 📑: https://learn.microsoft.com/en-us/dotnet/api/system.timeprovider?view=net-8.0


```csharp
// 1️⃣ Use the real system time
BasedOnTime(TimeProvider.System);

// 2️⃣ For testing we can pass FakeTimeProvider with a custom set date
var fakeTimeProvider = new FakeTimeProvider(new DateTimeOffset(new DateTime(2024, 1, 1)));

fakeTimeProvider.AutoAdvanceAmount = TimeSpan.FromDays(1);
BasedOnTime(fakeTimeProvider);

void BasedOnTime(TimeProvider timerProvider)
{
    var utcNow = timeProvider.GetUtcNow();
    Console.WriteLine($"Utc Now: {utcNow});
}
```