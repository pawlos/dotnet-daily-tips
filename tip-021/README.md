# 021 - Watch window formatters #

Another debugging topic today.

Let's look closer at Watch window 🔍 in Visual Studio.

Using it, we can observe values of our variables while the code is running but sometimes that's not enough. To enhance we can provide a specifier - an extra value after a comma, that will influence how, the value is displayed.

For example, if we want to print a string value and strip the quotes, we can use `",nq"` to achieve that.

Adding `",h"` will print numerical value as hexadecimal and `",d"` will format it as decimal. The full list is available via the link below 👇.

🔗 See the full docs: [Format specifiers in C# in the Visual Studio debugger](https://learn.microsoft.com/en-us/visualstudio/debugger/format-specifiers-in-csharp?view=vs-2022)
