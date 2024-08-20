# 048 - System.Numerics #

Interesting find no 754.

When looking at interesting topics for daily bits of info one can always find something new. This time when investigating SIMD topic I've stumbled upon this struct: TotalOrderIeee754Comparer<T>.

The name looks funny due to lowercase l looking like capital i. So in fact, it's not Orderleeee754- but OrderIEEE754Comparer😉.

Funny stuff aside, if you are doing any more serious calculation you should check that out. For example regular compare would not distinguish between negative and a positive zero. This one does as the standard specifies..

Docs: 📑 https://learn.microsoft.com/en-us/dotnet/api/system.numerics.totalorderieee754comparer-1?view=net-8.0

Did you had a chance to use this IEEE754 comparer in your project?


```csharp
using System.Numerics;

var comparer = new TotalOrderIeee754Comparer<float>();
const float positiveZero = +0f;
const float negativeZero = float.NegativeZero;

// ✅ Prints 0 => -0 == +0
Console.WriteLine(negativeZero.CompareTo(positiveZero));

var compare = comparer.Compare(negativeZero, positiveZero);
// ✅ Prints -1 => -0 <= +0
Console.WriteLine(compare);
```