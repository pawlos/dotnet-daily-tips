# 055 - `::` operator #

Is the `::` operator the least useful operator in C#? YMMV but I think I've used it once, or twice it in my .NET coding journey starting from .NET Framework 1.1.

Documentation (see the link below) suggests some usages but to be honest I've only seen it in some old ASP.NET WebForms application in conjunction with global namespace. Something like global::Page, apart from that it's a mystery for me. We could prepend the global namespace with it but why 👇?

Do use this operator on a daily basis? Are there any valid and good cases for it to exists?
I'm probably wrong but it seems like we won't lose much if it would be gone?

Docs 📑: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/namespace-alias-qualifier


```csharp
var list = new System.Collections.Generic.List<int>();
var global_list = global::System.Collections.Generic.List<int>();
```