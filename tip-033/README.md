# 033 - appsettings - In Memory provider #

Today's tip will be helpful if you need to avoid relying on external sources for configuration.

Files are good for storing the values for production needs but are not the best if we need to read those in our integration tests.

External dependency in best scenario will be slow and in worst one it could lead to errors ❌ in tests that would not be problems in the logic that we test.

In such scenario Memory provider is useful. We can initialize it with a collection of keyvaluepairs and we are good to go ✅.

See the example 👇.

Docs: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-8.0#memory-configuration-provider

```csharp
var memorySettings = new KeyValuePair<string,string>[]
{
    new("MyKey", "Dictionary MyKey Value"),
    new("Position:Title", "Dictionary_Title"),
    new("Position:Name", "Dictionary_Name"),
    new("Logging:LogLevel:Default", "Warning")
};

builder.Configuration.AddInMemoryCollection(memorySettings);
```
