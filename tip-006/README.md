# 006 - Are we interface obsessed? #

During one of the live sessions, while writing some tests, we stumble upon the decision to extract generation of tracking numbers. We would inject our dependency into the .ctor, but into what it should be extracted?
We would like to allow testing so interface sounds like a natural decision to do that but, that's not the only way to go, right?

A simple Func<> could be used for that purpose. It's simple as it would not require any new types to be created where interface would require one implementation for normal usage and one for testing purposes. Alternatively using a mocking framework to handle the call to this object to define the appropriate behavior.

Func<> seems to be a clear winner here yet the interface one felt a bit more natural solution than the Func<>. But maybe we are, as a dotnet community, interface obsessed? What do you think?🤔

Injection with an interface
```csharp
public class NewParcelHandler(
    IParcelsStore parcelsStore,
    ITrackingNumberGenerator trackingNumberGenerator
)
{
    // omitted
}
```
or with just a simple Func<>?
```csharp
public class NewParcelHanler(
    IParcelsStore parcelsStore,
    Func<TrackingId> trackingNumberGenerator
)
{
    // omitted
}
```