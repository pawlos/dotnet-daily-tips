# 046 - Minimal class/interface/record/struct #

Small C#12 change everyone missed.

C#12 brings few changes to the language. Primary constructor, collection expressions, alias any type and so on. But there's one small change that almost no one is talking about.

Previously, for an empty record we could use really short notation like `record MyRecord;` - that's it what was needed by the language. But it was not working for classes, structs or interfaces. You would still need to add the curly brace - twice (opening & closing one). C# 12 bridges that gap and now you can use this minimal form for all the types 👇.


```csharp
// ❗ before C# 12
class MinimalClass {}

interface IMinimalInterface {}

struct MinimalStruct {}

record MinimalRecord {}

// ✅ from C# 12
class MinimalClass;

interface IMinimalInterface;

struct MinimalStruct;

record MinimalRecord;
```
