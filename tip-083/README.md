# 083 - P/Invoke #

P/Invoke is a way to allow unmanaged libraries from managed code. In the old days, it was a way to access Windows API that was not yet available in the .NET framework.

Since .NET became multi-platform, being present on Mac and Linux, P/Invoke has also been available on those platforms.

To import a native method that we would like to use, we need to create a static extern function and mark it with the DllImport attribute.

The `DllImport` attribute allows us to specify the native library from which the function should be loaded, as well as some extra parameters to cover more complex scenarios.

Docs 📑: https://learn.microsoft.com/en-us/dotnet/standard/native-interop/pinvoke

```csharp
namespace PInvokeSamples;

public static class Program
{
    // Import the libc shared library and define the method
    // corresponding to the native function.
    [DllImport("libc.so.6")]
    private static extern int getpid();

    public static void Main(string[] args)
    {
        // Invoke the function and het the process ID
        int pid = getpid();
        Console.WriteLine(pid);
    }
}
```
