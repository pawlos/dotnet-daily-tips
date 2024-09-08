# 067 - Discards #

Talking about deconstructing, it's not possible to not mention discards.

Deconstructing an object is nice, but sometimes we only care about certain values from the deconstructed object. We could, of course, declare extra variables and just not use them, but why the extra need for dealing with one of the most difficult things in IT - naming things - if we can live without that?

Discards come into play here (not only here). We could use a discard character, such as an underscore (_), for some of the variable names in the deconstruction. This will tell the compiler that we do not care about the variable and we don't need it. The compiler will take care of extracting only the values we need, and we end up with code that's not polluted by unnecessary variables. Nice and simple.

Docs 📑: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/discards


```csharp
Process p = Process.Start("notepad.exe", "");
await p.WaitForExitAsync();

// 1️⃣ we would like to deconstruct process to get just the pid, use the discard
(int pid, _) = p;


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