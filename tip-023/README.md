# 023 - Pseudovariables in Watch window #

Another debugging topic today. And another look at Watch window 🔍 in Visual Studio. Using it, we can observe values of our variables while the code is running but sometimes that's not enough. We can use pseudo variables.

The documentation 📑 is attached as link below 👇 but it doesn't contain the full list.

- 📌 $exception is probably the most known one; it holds the last thrown exception
- 📌 $returnvalue holds the result of the function right after we exit
- 📌 $asyncStateMachine - the state machine object, available inside async method
- 📌 $threadSmallObjectHeapBytes, $threadUserOldHeapBytes - give an info about how much bytes were allocated by the current thread

🔗 See the docs: [Pseudovariables in the Visual Studio debugger](https://learn.microsoft.com/en-us/visualstudio/debugger/pseudovariables?view=vs-2022)
