# 074 - `StackTraceHidden` #

`System.Diagnostics` is a vast source of interesting classes. One such gem is the StackTrace class. It allows us to collect the frames of the current execution call if we need to know how we ended up at a particular location. This information might be useful for diagnostic purposes.

A stack trace will provide the most information in Debug mode since it includes debug symbols.

Connected with the stack trace is the `StackTraceHidden` attribute. This attribute allows us to decorate methods that should be hidden from being included when the stack trace is printed. These methods will show up if we iterate through all the frames in the stack trace, but they will not appear if we use `.ToString()`.

Docs 📑: https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.stacktrace?view=net-8.0


```csharp
Function1();
return;

[StackTraceHidden]
void Function1()
{
    Function2();
}

void Function2()
{
    // ✅ pass true, to collect file:line:column info
    var st = new StackTrace(true);
    // 1️⃣
    Array.ForEach(st.GetFrames(), Console.WriteLine);
    // 2️⃣
    Console.WriteLine(st.ToString());
}

// 1️⃣ This is how it will be printed
//<<Main>$>g__Function2|0_1 at offset 83 in file:line:column <...>\Program.cs:14:5

//<<Main>$>g__Function1|0_0 at offset 31 in file:line:column <...>\Program.cs:9:5

//<Main>$ at offset 35 in file:line:column <...>\Program.cs:4:1

// 2️⃣ This is how it will be printed
// at Program.<<Main>$>g__Function2|0_1() in <...>\Program.cs:line 15
// at Program.<Main>$(String[] args) in <...>\Program.cs:line 4
```