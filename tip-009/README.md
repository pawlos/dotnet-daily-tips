# 009 - Wolverine source generation #

Back to Wolverine topic. One of the interesting (or unique) feature is that Wolverine can work in a fashion that our bindings are source generated. If we are in the development mode that's not very beneficial as we would be generating based on a constantly changing code but once we are fairly done we can use the magic of source generation and get rid of reflection for resolving the handlers. Link to the docs: https://wolverine.netlify.app/guide/codegen.html

The topic of source generating parts of the previously dynamic code is something we will see more and more often.

```csharp
builder.Host.UseWolverine(options =>
{
    // use Auto to generate/load generated types or Static in Production to load
    options.CodeGeneration.TypeLoadMode = TypeLoadMode.Auto;
});
```