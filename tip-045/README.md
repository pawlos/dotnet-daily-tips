# 045 - ReadyToRun #

If application startup time & latency is an issue the new ReadyToRun format for your application. ReadyToRun is an Ahead-of-Time (AOT) compilation.
Due to the fact that R2R assemblies won't require JIT work when assembly is loaded. ReadyToRun application contain both Native and Manged code as the last one can be used for certain scenarios

To produce ReadyToRun code we need to pass an extra parameter when publishing platform-specific application version. See attached example 👇

Docs 📑: https://learn.microsoft.com/en-us/dotnet/core/deploying/ready-to-run

```csharp
// ✅ add PuhlishReadyToRun=true top indicate AOT ReadyToRun mode
dotnet publish -c Release -r win-x64 -p:PublishReadyToRun=true
```
