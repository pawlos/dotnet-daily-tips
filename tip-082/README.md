# 082 - Out Of Memory exception #

Quite recently, I had to deal with an Out of Memory exception, which reminded me of an old .NET interview question so today a bit of .NET trivia.

How does the .NET framework throw an Out of Memory exception if there's no memory to be allocated? You can pause reading the post and try to answer that one if you didn't know before.

It's simple. This exception (and a few others) are pre-allocated when the process starts. So if it's needed to be thrown, it's already there. No need for allocating anything.

It's possible to spot this by running any profiler, which would indicate that an OutOfMemory exception was created. I've attached the log from my toy profiler 👇

Docs 📑: https://learn.microsoft.com/en-us/dotnet/api/system.outofmemoryexception?view=net-8.0

Do you know any other interesting, fun or strange .NET trivia? If yes, please share 🙏.


```
OctoProfiler::Initialize started...v0.0.1
OctoProfiler::Detected .NET 6.0.32
...
OctoProfiler::ObjectAllocated 128 [B] for System.OutOfMemoryException
OctoProfiler::DoStackSnapshot end
OctoProfiler::ObjectAllocated 128 [B] for System.StackOverflowException
OctoProfiler::DoStackSnapshot end
OctoProfiler::ObjectAllocated 128 [B] for System.ExecutionEngineException
OctoProfiler::DoStackSnapshot end
```