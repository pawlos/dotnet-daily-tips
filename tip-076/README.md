# 076 - utf-8 Strings Literals #

.NET strings use UTF-16 encoding, so it can be a problem when one needs to exchange data with a system that uses, for example, UTF-8. The web is based on UTF-8, and for that reason, C# 11 introduces UTF-8 strings. They are constructed by appending the u8 suffix to the string literal. They are also not typed as string but rather as `ReadOnlySpan<byte>`.

While not necessarily useful in day-to-day coding, it might be useful to know about them anyway.


Docs 📑: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-11.0/utf8-string-literals
