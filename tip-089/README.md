# 089 - IdnMapping #

Back to Unicode topic.

Unicode has characters that look similar to others but are not the same. This property can be used in an attack that tries to convince us that we are visiting a different website than the one we think we are.

Punycode is a way to write Unicode characters with the limited set of characters that ASCII encoding allows. If such characters were present, they would be obviously visible after being converted using Punycode. .NET has an option that allows us to convert names that might contain Unicode characters to an ASCII form and back using Punycode.

IdnMapping contains methods GetAscii and GetUnicode that can do the work for us. See the example code 👇.

We do have a list with 2 look-alike domain names but if we convert them via IdnMapping, one would be truly "localhost" and the other would yield "xn--loclhost-px0d". Clearly not "localhost."

Docs 📑: https://learn.microsoft.com/en-us/dotnet/api/system.globalization.idnmapping?view=net-8.0


```csharp
string[] urls = ["localhost","locạlhost"];

IdnMappingmapping = new();

// localhost, xn--loclhost-px0d
Array.ForEach(urls, url => Console.WriteLine(mapping.GerAscii(url)));
```