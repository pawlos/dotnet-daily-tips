# 007 - MemberNotNullWhen #

Using our Result<T> class (see [Tip-001](../tip-001/README.md)) poses one problem. In some cases Value can be null and in some cases Error would be null. We can check that with an IsSuccessful but compiler won't be able to use that info to determine that the Value is not null. It will complain in the editor that the value might be null. We can help it though.

Using MemberNotNullWhen attribute to indicate when Value is not null and when Error is not based on the IsSuccessful attribute. With that additional help - no red squiggly.

Documentation about the attribute: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/nullable-analysis