# 068 - A standalone discard #

Discards are not complex construct but there's still one interesting use-case worth mentioning.

We can use discard when we use an operator that needs a left-hand side value but we actually do not care about. One of such operator is `??` - null-coalescing. To use it we need something on the left side as we can't just write

```
valueToProcess ?? throw new ArgumentNullException(nameof(valueToProcess));
```

but we can write

```
_ = valueToProcess ?? throw new ArgumentNullException(nameof(valueToProcess));
```

One just need to remember that _ is still a valid identifier in some context so it might produce unexpected results if one is not careful enough.

Docs 📑: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/discards#a-standalone-discard
