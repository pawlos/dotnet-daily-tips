# 035 - DOTNET_JitDisams #

❓ Do you know that you can see the assembly that JIT generates for your methods?

There are few environment variable available that control dotnet runtime, SDK or CLI. One of such variable is DOTNET_JitDisasm.

We can set it to point to a method name (in Powershell $env:DOTNET_JitDisasm="Main"). If later we run a program in console and if such method gets jitted, we will get assembly listing for its' code 👨‍💻.

If you are dealing with low level performance issues, you can use this to see what assembly is generated and if that could be, for some reason, the culprit for the problem.

Try running the attached program with and without setting the environment variable.