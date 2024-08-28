# 056 - `await` vs `Task.WhenAll` #

There's a difference between calling await three times on some Task and collecting 3 tasks and calling `Task.WhenAll`.

In the first case each await will be called one by one, probably giving some time benefit of doing it async, but in the second case we call all 3 tasks together we can gain more.

So if you have few task to run consider awaiting them together with `Task.WhenAll`.


```csharp
// ❌ Don't call await in sequence
var ingredients = await api.LoadIngredients();
var recipes = await api.LoadRecipes();
var menu = await api.LoadMenu();
```

```csharp
// ✅ use Task.WhenAll to wait for all tasks to complete asynchronously
var ingredientsTask = api.LoadIngredients();
var recipesTask = api.LoadRecipes();
var menuTask = api.LoadMenu();
Task.WhenAll([ingredientsTask, recipesTask, menuTask])
```