# 036 - GC Limits #

Do you know that you can control Garbage Collection settings? It was possible to set GC config for the start of the application but now, in the latest release of .NET, we do have a function to instruct GC to reload its configuration ♻.

So now we can set the desired limit via AppContext.SetData and call the `GC.RefreshMemoryLimit`. This could be useful for cloud or containerized environment.

```csharp
AppContext.SetData("GCHeapHardLimit", (ulong)300 * 1_024 * 1_024);
GC.RefreshMemoryLimit();
```

See the docs for full information about it and also attached code example demonstrating usage 👇

Docs 📑: https://learn.microsoft.com/en-us/dotnet/api/system.gc.refreshmemorylimit?view=net-8.0#system-gc-refreshmemorylimit

```csharp
// 🛑 GC hard limit at 200 MB
AppContext.SetData("GCHeapHardLimit", (ulong)200 * 1_024 * 1_024);
GC.RefreshMemoryLimit();

List<byte[]> bytes = new List<byte[]>();
for (int i = 0; i < 200; i++)
{
    byte[] b = new byte[1_024 * 1_024];
    bytes.Add(b);
}
```