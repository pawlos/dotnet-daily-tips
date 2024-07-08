# 034 - appsettings - Multiple providers #

Today's is the tip that I should start this mini-series with🎯.

The last two days it was about using different providers instead of the default one. But using (or I should write adding) different provider does not mean ditching the old one. We can add many of them and settings will be merged together. The order is important though. We will get different setting value if we register them in different order (assuming they all have the value defined).

The last registered provider's value will win. See the following example 👇

Docs 📑: https://learn.microsoft.com/en-us/dotnet/core/extensions/configuration-providers

```csharp
var memorySettings = new KeyValuePair<string,string>[]
{
    new("Logging:LogLevel:Default", "Warning")
};

builder.Configuration.AddInMemoryCollection(memorySettings);
builder.Configuration.AddJsonFile("appsettings.json");
//appsettings.json contains Logging:LogLevel:Default set to Trace
builder.Configuration.AddKeyPerFile(Directory.GetCurrentDirectory());
//file Logging__LogLevel__Default with value Trace exists

Console.WriteLine($"{app.Configuration["Logging:LogLevel:Default"]}");
// the above line would print Trace
```