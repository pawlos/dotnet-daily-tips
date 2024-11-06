# 092 - InternalsVisibleTo #

Keeping everything public might be considered an anti-pattern. On the other hand, if we use more restrictive access modifier, we might encounter situations where something that we would like to access would not be possible. The `InternalsVisibleTo` attribute might come in handy in such situations.

Using this attribute, we can specify that the assembly mentioned in the attribute, will be able to access internal types specified in the one where the attribute is used. This means types that are marked with internal access modifier, internal protected, or private protected ones will be accessible. We could use this to allow access to some internal types for a test project. See the example code 👇.

Docs 📑: https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-runtime-compilerservices-internalsvisibletoattribute

Did you know about this attribute? Did you use this one?

```csharp
// Project B
[assembly: InternalsVisibleTo("ProjectA")]
namespace Logic;

internal class ImportantLogic
{
    internal void DoStuff()
    {
        // important logic
    }
}

// Project A will see the internal class
var logic = new ImportantLogic();
ic.DoStuff();
```