# 057 - Task methods #

Apart from WhenAll, used in on the previous day, Task has also some other static methods that can be useful if we have more than one task to run.

- 📌 `Task.WhenAll` - to wait for the results of multiple tasks
- 📌 `Task.WhenAny` - if we don't care about which one finishes, as long as at least one does
- 📌 `Task.WaitAll` - to wait on all task, or till cancellation token gets call, or number of milliseconds elapsed
- 📌 `Task.WaitAny` - similar to the above one, but we only care about one task.

- 📌 `Task.FromResult<T>` - creates completed task, with specific result
- 📌 `Task.FromException<T>` - creates completed task, with an exception
- 📌 `Task.FromCanceled<T>` - creates completed task, due to cancellation token being called

Good to know they exists and use them when needed.




```csharp
// Task has few methods that can be useful in certain situations
Task.WhenAll();

Task.WhenAny();

Task.WaitAll();

Task.WaitAny();

Task.FromResult<T>();

Task.FromException<T>();

Task.FromCanceled<T>();
```