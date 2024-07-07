# 032 - appsettings - Setting per file  #

appsettings.json is a standard file that holds application configuration but it's not the only one. There are multiple providers and one of them allows to have configuration per file?

To enable it use `builder.Configuration.AddKeyPerFile(Directory.GetCurrentDirectory());` and make sure the files names are the same as your configuration sections. If needed replace ':' with double '_'.

Docs: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-8.0#key-per-file-configuration-provider
