# 016 - Breaking changes #

.NET platform is considered to be stable platform but from version to version there are changes that are considered a breaking ones. When updating to the new version do you check what are the changes that might impact your project or just update & YOLO?

I do remember one case, long time ago that updating to .NET Framework 4.6 caused a lot of issues and resulted in digging through documentation and framework source code finding that one switch that could revert back to the old behavior - `Switch.MS.Internal.DoNotUseCulturePreservingDispatcherOperations`.

See the full list of changes in .NET 8: https://learn.microsoft.com/en-us/dotnet/core/compatibility/8.0