# 084 - `LibraryImport` #

P/Invoke does allow linking with unmanaged libraries, but it does not work correctly with trimming and ahead-of-time compilation, which are key features of building performant .NET libraries. To mitigate this, a new attribute was introduced - `LibraryImportAttribute`.

`LibraryImport` is similar to `DllImport` with a few exceptions. The method should be partial instead of extern, and we can provide both the library name and the method name. Dealing with string types requires adding information about marshaling to correctly map the value.

One important thing to note is that the project must be marked with AllowUnsafeBlocks.

Docs 📑: https://learn.microsoft.com/en-us/dotnet/standard/native-interop/pinvoke-source-generation


```csharp
namespace LibraryImportSamples;

public class NativeLibs
{
    [LibraryImport("libc.so.6")]
    internal static partial int getpid();
}

public static class Program
{
    public static void Main(string[] args)
    {
        int pid = NativeLibs.getpid();
        Console.WriteLine(pid);
    }
}
```
