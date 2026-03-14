# 041 - Publishing #

Once we are done with our code we should publish the application. And doing that faces us with yet another decision to make. How do we want our application to be published?
We can use one of the two available modes, and depending on that it will affect how user will run the app.

We can pick self-contained, that includes .NET runtime and libraries, and the app of course along with its dependencies. This way users without .NET runtime can still run it.

Picking framework-dependent option, generates application that includes only the application files plus the dependencies. Users of your applications would have to install .NET runtime to make it work.
Apps in this mode are cross-platform though (unless you are using some platform specific code).

Framework dependent:
- ➕ smaller deployment
- ➕ cross-platform
- ➕uses latest runtime
- ➖requires preinstalled runtime
- ➖might fail if the runtime changes behavior (it might happen, see post from [Day-16](../tip-016/README.md))

Self-contained:
- ➕ deployed with specific version of .NET, you are sure if the app worked it will work
- ➖larger deployment
- ➖more difficult to update .NET version; update = new release

Docs 📑: https://learn.microsoft.com/en-us/dotnet/core/deploying/

