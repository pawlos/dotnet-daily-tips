# 037 - GC Limits again #

You might be asking some questions reading yesterday's post. Why I would need to modify GC Hard limit settings❓

In most cases - you don't want to. But if you are running in a container you might want to consider being explicit.

GC by default reserves higher of the two: 20 MB or 75% of available memory (https://github.com/dotnet/runtime/blob/main/src/coreclr/gc/gcpriv.h#L5127). But memory might be needed for some other type of resources. Depending on the case it might be correct or it might be too low or too much. `AppContext.SetData` allows us to be specific 🔎 about our managed memory needs.

So again, if you work in a constraint environment consider

```csharp
AppContext.SetData("GCHeapHardLimit", (ulong)300 * 1_024 * 1_024);
GC.RefreshMemoryLimit();
```

