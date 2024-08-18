# 043 - Trimming options #

Continuing topic about trimming the final binary 🗜. Lets discuss what options we do have for that. Trimming without configuring options would be useful only in very limited number of cases.

- 1️⃣ First, we can set trim mode to be full or partial. In partial mode, we can specify which assemblies shall be trimmed and which should not be touched.
- 2️⃣ We can also specify additional assemblies (and it's dependencies) shall not be trimmed - `<TrimmerRootAssembly>`.

Some other options that can be used during the process:
- 1️⃣ `<TrimmerSingleWarn>false</TrimmerSingleWarn>` - shows more details warnings
- 2️⃣ `<TrimmerRemoveSymbols>true</TrimmerRemoveSymbols>` - cleans PDBs, including embedded ones. In both the app & dependencies.
- 3️⃣ `<DebuggerSupport>false</DebuggerSupport>` - removes support for the debugger, including symbols (2️⃣)

Docs📑: https://learn.microsoft.com/en-us/dotnet/core/deploying/trimming/trimming-options?pivots=dotnet-8-0


```csharp
<PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net9.0</TargetFramework>
    <ImplicitUsing>enable</ImplicitUsing>
    <Nullable>enable</Nullable>

    <!-- add this 👇 -->
    <PublishTrimmed>true</PublishTrimmed>
    <!-- and those as needed 👇>
    <TrimMode>partial</TrimMode>
    <TrimmerRemoveSymbols>true</TrimmerRemoveSymbols>
</PropertyGroup>
```