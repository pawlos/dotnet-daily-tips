# 010 - Primery constructors#

What's your take on C# 12 Primary constructor feature? Love them? Hate them? Just use them? I've just discovered that one must be really careful not to mistype as there's a small fine difference between the two following entries:

```csharp
public record SenderEntity(int? Id, string Name, string Address);
```

```csharp
public class SenderEntity(int? Id, string Name, string Address);
```

In the first example we declare a record and `Id`, `Name` and `Address` will be exposed as public properties. In the second one, we delcare a class with a primary constructor taking such arguments, but nothing is exposed outside the class.

Link to the docs: https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-12#primary-constructors