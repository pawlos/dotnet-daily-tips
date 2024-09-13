# 073 - TimeProvider #

`Single`, `Double`, and `Decimal` - the three floating-point types available in .NET. But did you know there's a fourth type?

`Half` is a fourth type that was introduced in .NET 5. To be honest I've must have missed it myself. It is 2 bytes in size and allows storing values up to around 65k. It also allows representing positive and negative zeros, +∞, -∞, and of course, NaN.

For the Half type, there are a few constants defined that represent common values used in calculations like E, Pi, and tau.

Docs 📑: https://learn.microsoft.com/en-us/dotnet/standard/numerics#floating-point-types
https://learn.microsoft.com/en-us/dotnet/api/system.half?view=net-8.0

Did you know about this type? Or maybe you've already used it?
