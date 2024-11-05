# 090 - Character categories #

Still Unicode. It's a vast topic.

Today, character categories. There are a lot of characters in Unicode (version 15.1 says around 300k) and those are clustered into categories. Some categories are standard, like lowercase letters, uppercase letters, or numbers.

In .NET, we can get those categories by using the `CharUnicodeInfo` class and calling `GetUnicodeCategory`. In our astronaut example, calling `CharUnicodeInfo.GetUnicodeCategory("👨‍🚀", 3)` would give us "Format" as the Zero-Width Joiner is in the Format category. See the attached example for a few more examples 👇.

Docs 📑: https://learn.microsoft.com/en-us/dotnet/api/system.globalization.unicodecategory?view=net-8.0

```csharp
string text = "Lo₱∑😃";

// L is in UppercaseLetter category
Console.WriteLine(CharUnicodeInfo.GetUnicodeCategory(text, 0));

// o is in LowercaseLetter category
Console.WriteLine(CharUnicodeInfo.GetUnicodeCategory(text, 1));

// ₱ is in CurrencySymbol category
Console.WriteLine(CharUnicodeInfo.GetUnicodeCategory(text, 2));

// ∑ is in MathSymbol category
Console.WriteLine(CharUnicodeInfo.GetUnicodeCategory(text, 3));

// 😃 is in OtherSymbol category
Console.WriteLine(CharUnicodeInfo.GetUnicodeCategory(text, 4));

// Zero-Width joiner \200D is in Format category
Console.WriteLine(CharUnicodeInfo.GetUnicodeCategory("👩‍🚀", 2));
```