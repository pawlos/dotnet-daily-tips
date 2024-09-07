# 066 - Deconstruct #

Another duck-typing 🦆 post. A few days ago, I covered the GetAwaiter method that allows adding await functionality to any type. Today, another feature that relies on the same construct.

Deconstruction is a feature that allows extracting separate values out of a tuple. But what if we would like to deconstruct a type that is a bit more complex than a tuple? We can do it with the help of duck typing.

Deconstruction will work if the compiler detects a Deconstruct method that matches the call that we are trying to make. For example, let's try to deconstruct a Process. See the example below.

We start the process and wait for it to exit. In 1️⃣, we would like to use deconstruction to assign Pid & ExitCode to two variables. It won't work out of the box. But we can write an extension method 2️⃣ that the compiler would be able to use to perform the deconstruction.

Docs 📑: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct


```csharp
Process p = Process.Start("notepad.exe", "");
await p.WaitForExitAsync();

// 1️⃣ we would like to deconstruct process to pid and exit code
(int pid, int exitCode) = p;


public static class ProcessExtensions
{
    // 2️⃣ Provide extension method to allow Deconstruct
    public static void Deconstruct(this Process p, out int pid, out int exitCode)
    {
        pid = p.Id;
        exitCode = p.ExitCode;
    }
}
```