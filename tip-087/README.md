# 087 - System.Console.OutputEncoding #

Playing with Unicode characters in the console might result in seeing a lot of � or ???? instead of nice characters. This is due to the fact that by default, console encoding is set to ASCII. To change that, set the OutputEncoding to another encoding like UTF-8 or Unicode. See the attached example code 👇

In the first call 1️⃣, "Hello ?????" will be printed, as ASCII encoding cannot handle this Unicode character. By setting the encoding to UTF-8 2️⃣, we can see the astronaut being printed.

Docs 📑: https://learn.microsoft.com/en-us/dotnet/api/system.console.outputencoding?view=net-8.0


```csharp
var text = "Hello \uD83D\uDC68\u200D\uD83D\uDE80";

// 1️⃣ Hello ?????
Console.WriteLine(text);

Console.OutputEncoding = Encoding.UTF8;
// 2️⃣ Hello 👨‍🚀
Console.WriteLine(text);
```
