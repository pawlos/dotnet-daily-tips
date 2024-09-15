# 075 - TryGetNonEnumeratedCount #

Working with `IEnumerable<T>` is nice as we do not need to limit ourselves to only one concrete type. But with great power comes great responsibility. When dealing with a non-concrete type, we do not know if calling an action will materialize the collection by enumerate all the elements. It might not be what we want.

For that purpose, a new method, `TryGetNonEnumeratedCount`, was created. It will attempt to get the count without enumerating. If it's possible, we will have it. The method returns `true` if it succeeds.

See the example below. In the case of method 1️⃣, we limit the collection but we do not materialize it. In the case of the second call 2️⃣, we do materialize it by calling `.ToList()`. The result of calling `TryGetNonEnumeratedCount` is different.

Docs 📑: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.trygetnonenumeratedcount?view=net-8.0


```csharp
var enumeratedFrames = GetStackTrace1();
var nonEnumeratedFrames = GetStackTrace2();

PrintFramesCount(enumeratedFrames); // 1️⃣
PrintFramesCount(nonEnumeratedFrames); // 2️⃣
return;

void PrintFramesCount(IEnumerable<StackFrame> frames)
{
    Console.WriteLine(frames.TryGetNonEnumeratedCount(out int count)
    ? $"Number of frames: {count}"
    : "Coult not get frame count w/o enumerating");
}

IEnumerable<StackFrame> GetStackTrace1()
{
    var st = new StackTrace(true);
    return st.GetFrames().Where(x => x.HasILOffset());
}

IEnumerable<StackFrame> GetStackTrace2()
{
    var st = new StackTrace(true);
    return st.GetFrames().Where(x => x.HasILOffset()).ToList();
}

// 1️⃣ Coult not get frame count w/o enumerating
// 2️⃣ Number of frames: 2
```