# 052 - Capacity vs Count #

Capacity is not the same as Count.

Lists and other collections in .NET allocate memory on a need basis (unless specific size requirements are provided in the constructor) and resize the internal size as needed. The resize algorithm is simple and it will grow the collection times 2 if more space is needed. It only works for growing the collection if we want to reclaim the no longer needed space, after removing some elements, we need to do it manually by calling `TrimExcess`.

When dealing with collection remember those two rules.

- 1️⃣ Pass expected collection size (if known and if it's manageable size)
- 2️⃣ Call TrimExcess to reclaim no longer needed space

Docs 📑: https://learn.microsoft.com/en-us/dotnet/standard/collections/


```csharp
// Preallocating list; we expect this is the size of the list - it may or may not be true
var list = new List<int>(512);

// List count 0, capacity 512 - Capacity as expected
Console.WriteLine($"List count {list.Count}, capcity {list.Capacity}");

list.AddRange(Enumerable.Range(1, 513));

// List count 513, capacity 1024 - capacity grew as we exceeded the original capacity
Console.WriteLine($"List count {list.Count}, capcity {list.Capacity}");

list.RemoveAll(x => x > 230);

// List count 230, capcity 1024
Console.WriteLine($"List count {list.Count}, capcity {list.Capacity}");

// Reclaim not-needed space
list.TrimEscess();

// List count 230, capcity 230
Console.WriteLine($"List count {list.Count}, capcity {list.Capacity}");
```