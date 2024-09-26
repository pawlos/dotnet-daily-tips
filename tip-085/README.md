# 085 - Native library loading #

In the last two posts, we learned how we could use native libraries. When searching for a library to load, a few candidates are checked before it throws a DllNotFoundException.

If we specify in the code that we would like to load "test" 1️⃣, it will check a couple more: test.so, libtest.so, and test. We can see those in the exception output if the resolution fails 3️⃣. Only after all of those are not found will it throw an exception, causing our application to crash.

If needed, we can also attach our own resolver using NativeLibrary.SetDllImportResolver 2️⃣, which allows us to perform the resolution ourselves. One resolver per assembly can be registered with this method.

Docs 📑: https://learn.microsoft.com/en-us/dotnet/standard/native-interop/native-library-loading



```csharp
namespace LibraryImportSamples;

public class NativeLibs
{
    // 1️⃣
    [LibraryImport("test")]
    internal static partial int getpid();
}

public static class Program
{
    public static void Main(string[] args)
    {
        // 2️⃣
        NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), DllImportResolver);
        int pid = NativeLibs.getpid();
        Console.WriteLine($"Hello, World from {pid}");
    }

    private static IntPtr DllImportResolver(
        string libraryName,
        Assembly assembly,
        DllImportSearchPath? path)
    {
        Console.WriteLine($"Searching... {libraryName}");
        return IntPtr.Zero;
    }
}
// Output, in case we can't find the searched library will provide us with the information what was checked. 3️⃣ 👇
// Searching .... test
// Unhandled exception. System.DllNotFoundException: Unable to load shared library 'test' or one of its dependencies. In order to help diagnose loading problems, consider using a tool like strace. If you're using glibc, consider setting the LD_DEBUG environment variable:
// /usr/lib/dotnet/shared/Microsoft.NETCore.App/8.0.8/test.so: cannot open shared object file: No such file or directory
// /home/<user>/sources/dotnet/bin/Debug/net8.0/test.so: cannot open shared object file: No such file or directory
// /usr/lib/dotnet/shared/Microsoft.NETCore.App/8.0.8/libtest.so: cannot open shared object file: No such file or directory
// /home/<user>/sources/dotnet/bin/Debug/net8.0/libtest.so: cannot open shared object file: No such file or directory
// /usr/lib/dotnet/shared/Microsoft.NETCore.App/8.0.8/test: cannot open shared object file: No such file or directory
// /home/<user>/sources/dotnet/bin/Debug/net8.0/test: cannot open shared object file: No such file or directory
// /usr/lib/dotnet/shared/Microsoft.NETCore.App/8.0.8/libtest: cannot open shared object file: No such file or directory
// /home/<user>/sources/dotnet/bin/Debug/net8.0/libtest: cannot open shared object file: No such file or directory

//   at LoadingSamples.NativeLibs.getpid()
//   at LoadingSamples.Program.Main(String[] args) in /home/<user>/sources/dotnet/Program.cs:line 18
```
