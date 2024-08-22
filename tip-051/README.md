# 051 - Fixed-time equals #

Security has many traps that one can fall into if unprepared. We've already seen that using not correct Random class could lead to problems. Today let's look at comparison.

Comparing two values is probably one of the crucial operations but doing it incorrectly can possibly give an intruder a side-channel attacks based on time.

If our comparison takes more time if 1 elements is matching than if 0 is matched we can deduce what is the value that made the comparison took longer. That's a side channel attack. We do not observe the actual result but the effect on the environment. To mitigate that .NET has a fixed time equals.

🔑 `CryptographicOperations.FixedTimeEquals` provide a function that when executed consumes the amount of time that depends on the length of the sequences, but not their values.

Read more 📑: https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.cryptographicoperations.fixedtimeequals?view=net-8.0



```csharp
using System.Security.Cryptography;

var hash1 = new byte[16];
var hash2 = new byte[16];

if (CryptographicOperations.FixedTimeEquals(hash1, hash2))
{
    Console.WriteLine("Equals");
}
```