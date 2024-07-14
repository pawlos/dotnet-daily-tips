# 038 - Random.Shared #

Do you know that from .NET 6 you don't need to create Random class to be able to get pseudo-random values? There's a static, thread-safe instance that can be used to obtain those values. But the novelty doesn't end here. From .NET 8 we do have new methods available too.

We have the following two new methods under our belt:

- 📌 `Random.Shared.Shuffle` - allows reorganizing collection of items. Useful if we need to get elements in a random order.

- 📌 `Random.Shared.GetItems` - useful when picking k-elements for the collection. There's a caveat to that, though. Note, that it does not guarantee there won't be duplicates. Keep that in mind when using this method.

Docs:
- 📑https://learn.microsoft.com/en-us/dotnet/api/system.random.shuffle?view=net-8.0
- 📑https://learn.microsoft.com/en-us/dotnet/api/system.random.getitems?view=net-8.0
