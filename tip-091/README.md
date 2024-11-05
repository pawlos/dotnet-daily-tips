# 091 - ParseCombiningCharacters #

Few days ago we've talked about method [EnumerateRunes](../tip-086/README.md).

EnumerateRunes that we've learned is helpful but might not be enough. Trying to count characters in the following `"\uD83D\uDC68\u200D\uD83D\uDE80"` (👨‍🚀 = Man + ZWJ + Rocket) with chars or Runes might give us wrong results (5 vs 3). How can we get the correct number of elements?

StringInfo can help us with that. It has elements like `ParseCombiningCharacters` that allows to get the correct number. On the other hand, `GetTextElementEnumerator` allows getting an enumerator that allows traversing the elements of a string.

Docs 📑: https://learn.microsoft.com/en-us/dotnet/api/system.globalization.stringinfo?view=net-8.0

```csharp
Console.OutputEncoding = Encoding.Unicode;

string text = "\uD83D\uDC68\u200D\uD83D\uDE80";
int[] values = StringInfo.ParseCombiningCharacters(text);

var enumerator = StringInfo.GetTextElementEnumerator(text);

// 👨‍🚀
while (enumerator.MoveNext())
{
    Console.WriteLine(enumerator.GetTextElement());
}

// Only one entry. 0
Array.ForEach(values, Console.WriteLine);
```
