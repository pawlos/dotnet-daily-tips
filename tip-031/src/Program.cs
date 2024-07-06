using System.Diagnostics;

ExecuteLogMessagePreprocesorStyle();
ExecuteLogMessageAttributeStyle();

// ❌ Don't do this
void ExecuteLogMessagePreprocesorStyle()
{
    #if DEBUG
    LogMessageInDebugPreprocesorStyle();
    #endif
}

#if DEBUG
void LogMessageInDebugPreprocesorStyle()
{
    Console.WriteLine("Method active when DEBUG is defined");
}
#endif

// ✅ Do this instead
void ExecuteLogMessageAttributeStyle()
{
    // This call will only be in the compilation that does have DEBUG symbol defined
    LogMessageInDebugAttributeStyle();
}

[Conditional("DEBUG")]
static void LogMessageInDebugAttributeStyle()
{
    Console.WriteLine("Method active when DEBUG is defined");
}