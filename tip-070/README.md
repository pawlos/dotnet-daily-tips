# 070 - Regular expressions #

Regular expressions are one of the concepts that are almost universally used. Knowing, at least on a basic level, is also one of the core skills. Fanboys use [regex101.com](https://regex101.com) to check the matching/non-matching conditions and pros play with [regexcrossword.com](https://regexcrossword.com) in the free time. But did you know that one might get into trouble if not careful when writing a regex?

If we allow untrusted user input, we could be dealing with a Denial-of-Service attack 🎯. It can happen, if we do not prevent that, for example, by setting a timeout for how long the regular expression engine should process our data.

Especially problematic are inputs that almost match the provided patterns. If our regex relies on backtracking and the input almost matches, the engine might need to spend too much time trying to match that string and never succeed. It will see that more and more characters are matching but at the very end a non-matching one would occur causing the engine to return to previous state and try to pick a different matching route.

See the example code from the linked page below 👇

Docs 📑: https://learn.microsoft.com/en-us/dotnet/standard/base-types/best-practices-regex