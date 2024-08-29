# 058 - IO vs CPU-bound #

In async programming there are basically two types of operation that we are waiting for. IO-bound and CPU-bound. The first one is when we are waiting on some external resource - an API call, DB or a file. The later one is when we just need to do some intensive computation - e.g. raycasting.

For the first one, we do have async/await mode with `Task` & `Task<T>` types. For cpu-bound operations we should start a background thread with Task.Run method.

Of course, one sure measure before applying any performance related modifications as the benefits my not be enough to cover for the costs as nothing comes for free (e.g. context switching).

To sum up:
- 📌 IO-bound - waiting on resource
- 📌 CPU-bound - computation intensive

Docs 📑: https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/async-scenarios

