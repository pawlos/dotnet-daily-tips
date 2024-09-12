# 071 - `stackalloc` #

stackalloc is a relatively new keyword added to C#. It allows you to allocate a block of memory on the stack. Stack-allocated memory is a super-fast way to get a chunk of memory and is automatically discarded when the method returns. It's super fast because it's not allocated on the heap and does not need to be garbage collected. A stackalloc expression can be assigned to a variable of type `Span<>` or `ReadOnlySpan<>`, or to a pointer of that type if the unsafe keyword is used.

The stack has a limited amount of memory, so do not use this expression for larger chunks of memory. It will not work. Thankfully, if needed, normal heap allocation can also be assigned to `Span<T>`, so a nice one-liner can be used regardless of whether stackalloc is used or not.

Docs 📑: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/stackalloc

Have you been using stackalloc?

```csharp
const int MaxStackLimit = 1024;

Span<byte> buffer = inputLength <= MaxStackLimit ? stackalloc byte[MaxStackLimit] : new byte[inputLength];
```