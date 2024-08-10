# 042 - Publish trimmed #

[Yesterday](../tip-041/README.md), information about publishing options were shared. Today - and update to one of them.

With the self-contained application we have an option to reduce the output file size. Trimming (or tree-shaking) is a technique to remove unused part for the deployed binaries so that they only contain what's needed for the application to run. Thus making the deployment smaller 🗜.

This is an automated process so there is a chance that the analysis will yield wrong results so caution is required. We do get warnings during the build process if the trimmer can't analyze fully our code pattern.

To enable trimming we need to set PublishTrimmed to true in the project file. After that publish self-contained application.

Docs 📑: https://learn.microsoft.com/en-us/dotnet/core/deploying/trimming/trim-self-contained

```csharp
<PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net9.0</TargetFramework>
    <ImplicitUsing>enable</ImplicitUsing>
    <Nullable>enable</Nullable>

    <!-- add this 👇 -->
    <PublishTrimmed>true</PublishTrimmed>
</PropertyGroup>
```