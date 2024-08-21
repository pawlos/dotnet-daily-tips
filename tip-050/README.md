# 050 - Json serialization #

Tabs or spaces?

Do you prefer tabs or spaces? Or are you a fan of whitespace programming language? We won't get into IDE war here but maybe we I will start another one.

From .NET 9 you can specify what character json serializer will use.
IndentCharacter & IndentSize are the new properties that are introduced on JsonSerializerOptions.
Even though the first one is of type char and the second one takes an int, setting it to -2 as the size and '@' as the character did not work (I had to try 🤷‍♂️).

Will you find it useful to have those new configuration settings in your projects?

Docs 📑: https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-9/overview#indentation-options


```csharp
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

var options = new JsonSerializerOptions
{
    WriteIndented = true,
    IndentCharacter = '\t',
    IndentSize = 2,
    TypeInfoResolver = new DefaultJsonTypeInfoResolver()
};

string json = JsonSerializer.Serialize(
    new TabsVersusSpaces { Yes = true },
    options
);
```