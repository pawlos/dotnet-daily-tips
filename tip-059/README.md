# 059 - await anything #

async/await programming simplifies program structure. It seems linear and can be read as such but in fact it is not as straight as one might think. But if some classes doesn't support this programming model we can add it. async/await uses duck-typing🦆 so, if we make sure certain things are in place we can use this programming model too.

All we need to do is to make sure our type supports GetAwaiter method that returns `TaskAwaiter` or `TaskAwaiter<T>`.

With such loos requirements we can await ints, DateTimes and even Processes. Did you use this technique? What weird or interesting constructs did you create?


```csharp
public static class Awaiter
{
    public static TaskAwaiter GetAwaiter(this int v)
    {
        return Task.Delay(v).GetAwaiter();
    }

    public static TaskAwaiter<int> GetAwaiter(this Process process)
    {
        var taskCompletionSource = new taskCompletionSource<int>();
        process.EnableRaisingEvents = true;
        process.Exited += (_, _) => taskCompletionSource.SetResult(process.ExitCode);
        if (process.HasExited) taskCompletedSource.SetResult(process.ExitCode);
        return taskCompletionSource.Task.GetAwaiter();
    }
}
```