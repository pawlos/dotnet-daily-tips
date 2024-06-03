# 005 - Wolverine registration rules #

Method Handle and the Handler suffix is probably the most common naming conventions. But Wolverine supports other conventions. For the class we can use Handler or Consumer. It also works if we inherit from Wolverine.Saga or implement IWolverineHandler interface. If none of those works for us we can use WolverineHandlerAttribute and mark our class.

For the method name there's even more choices. We can name our method using on the the following names (+ Async suffix): Handle, Handles, Consume, Consumes, Orchestrate, Orchestrates, Start, Starts, StartOrHandles, NotFound. Again if none of those works for us we can use WolverineHandler attribute.

```csharp

// Method: a(ParcelByIdQuery)
// MISS -- Method name is 'Handle' (case sensitive)
// MISS -- Method name is 'HandleAsync' (case sensitive)
// MISS -- Method name is 'Handles' (case sensitive)
// MISS -- Method name is 'HandlesAsync' (case sensitive)
// MISS -- Method name is 'Consume' (case sensitive)
// MISS -- Method name is 'ConsumeAsync' (case sensitive)
// MISS -- Method name is 'Consumes' (case sensitive)
// MISS -- Method name is 'ConsumesAsync' (case sensitive)
// MISS -- Method name is 'Orchestrate' (case sensitive)
// MISS -- Method name is 'OrchestrateAsync' (case sensitive)
// MISS -- Method name is 'Orchestrates' (case sensitive)
// MISS -- Method name is 'OrchestratesAsync' (case sensitive)
// MISS -- Method name is 'Start' (case sensitive)
// MISS -- Method name is 'StartAsync' (case sensitive)
// MISS -- Method name is 'Starts' (case sensitive)
// MISS -- Method name is 'StartsAsync' (case sensitive)
// MISS -- Method name is 'StartOrHandle' (case sensitive)
// MISS -- Method name is 'StartOrHandleAsync' (case sensitive)
// MISS -- Method name is 'StartsOrHandles' (case sensitive)
// MISS -- Method name is 'StartsOrHandlesAsync' (case sensitive)
// MISS -- Method name is 'NotFound' (case sensitive)
// MISS -- Method name is 'NotFoundAsync' (case sensitive)
// MISS -- Has attribute [WolverineHandler]

// No Wolverine extensions are detected
// MISS -- Name ends with 'Handler'
// MISS -- Name ends with 'Consumer'
// MISS -- Inherits from Wolverine.Saga
// MISS -- Implements Wolverine.IWolverineHandler
// MISS -- Has attribute Wolverine.Attributes.WolverineHandlerAttribute
```