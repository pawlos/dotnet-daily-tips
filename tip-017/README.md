# 017 - static lambda #

Lambdas are probably the fastest way to write anonymous function. But it's also an easy way to create it in a way that captures variable creating unnecessary allocations.

There's an easy way to detect those. Just add `static` keyword to your lambda so that accidental captures are detected by the compiler.

Link to the docs: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/static-anonymous-functions

```csharp
// use the static ✅ keyword to prevent accidental capture of local variable or input parameter
data.Where(static x => x.CreatedBy == "admin");
```