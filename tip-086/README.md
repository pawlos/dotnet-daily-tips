# 086 - System.Text.Rune #

There's this recent post pointing out there are a couple of interesting methods in the char class like IsLetter or IsLetterOrNumber. The .NET API is so vast that I'm not surprised people are discovering new methods. One reason for my posts is to get familiar with things that might not be universally known. The char class has a lot of interesting functions, but one has to be careful when using them.

For majority of cases we could use char.IsLetter to check if a character is a letter in a string. That would be a mistake if, for example, we did it for words written in e.g. Osage. Checking letters with IsChar would yield 0 as a count. It's better to use the Rune class. Rune is a better replacement as it's aware of characters outside the Basic Multilingual Plane.

In example 1️⃣, using char.IsLetter would return 0. If we switch to Rune.IsLetter (as in 2️⃣), we would get the correct value of 4.

Docs 📑: https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-text-rune


```csharp

var a = "𐒹𐒰𐓏𐒷"; // Hello in Osage
// 1️⃣ returns 0
Console.WriteLine(CountLettersCharIsLetterExample(a));
// 2️⃣ returns 4
Console.WriteLine(CountLettersRuneIsLetterExample(a));

static int CountLettersCharIsLetterExample(string s)
{
    return s.Count(char.IsLetter);
}

static int CountLettersRuneIsLetterExample(string s)
{
    return s.EnumerateRunes().Count(Rune.IsLetter);
}
```
