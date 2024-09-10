# 069 - C# language specification #

We all probably know the C# language (I assume that if you're reading this post), but have you ever considered reading the language specification? Or maybe you've already done that? It's not the most thrilling document, but some sections are interesting when we consider that the language has some non-trivial situations to cover.

For example, how should `F(G<A, B>(7));` be evaluated? Is it a call to F with one argument being the value of the generic method G and the other argument being 7, or is it a call to the method F with two arguments, one being `G<A` and the other being `B>(7)`? Check section 6.2.5 about grammar ambiguities.

Another interesting section is Annex B - Portability Issues. It defines undefined behavior, implementation-defined behavior, and unspecified behavior, topics associated most often with other C languages.

Or read section 14.3 about namespace declaration. I didn't know all the things that are there.

Docs 📑: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/readme