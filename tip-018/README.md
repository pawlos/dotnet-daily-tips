# 018 - Debugger display #

`DebuggerDisplay` is an attribute that allows to define how does the object looks in the debugger. We can expose only those properties that we care about w/o the need of overriding `.ToString()`. But what about if we would like to redefine how does an object that we do not own?

We can use `DebuggerDisplay` attribute on assembly level, or use already prepared file that is delivered with Visual Studio's Debugger\Visualizer. If you look for `autoexp.cs` in Visual Studio folder you will find out buch of already predefined entries for `DebuggerDisplay` attribute. Just compile the file to a dll and restart VS and the debugger will be enriched with those definitions.

Docs: https://learn.microsoft.com/en-us/visualstudio/debugger/using-the-debuggerdisplay-attribute?view=vs-2022

```csharp
[DebuggerDisplay("{Value != null ? Value.ToString() : Error}")]
public class Result<T>
{
    // other members
    public T? Value { get; }

    public string? Error { get; }
}

[assembly: DebuggerDisplay("{Value != null ? Value.ToString() : Error}", Target = typeof(Result<Delivery>))]
```