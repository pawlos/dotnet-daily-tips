# 040 - Dark launching #

Do you know what Dark Launching is?

Imagine you need to refactor a certain piece of flow to use some new API. You could do it by replacing the old one, hoping that the new flow is well tested and covered. But you could do it differently. Adding the second implementation to the existing one, calling it, and... just ignoring the results. This way, you can battle tested your new implementation, checking for any potential differences between them and seeing if there are no edge cases that you forget about. This is what Dark Launching is.

Quite recently I've came across a .NET package that allows run such experiments and verifying or rejecting them based on data - Scientist.NET. You have to specify old flow and the experiment and Scientist.NET takes care of the rest. It's really easy and straightforward to use this for experimenting with multiple code solutions.


Links:
- 📑 https://martinfowler.com/bliki/DarkLaunching.html
- 📑 https://github.com/scientistproject/Scientist.net

Did you use such technique in your projects? Would you?

```csharp
return Scientist.Science<WeatherForecast[]>("weather-forecast", experiment =>
    experiment.Use(WeatherForecastsOld);
    experiment.Try("RandomNumberGenerator", WeatherForecastsNew); // experiment 1
    experiment.Try("Static", WeatherForecastsStatic); // experiment 2
    /* More options 👇
    * Define custom comparison logic
    * experiment.Compare((x,y) => x.Name == y.Name);
    *
    * Add extra context
    * experiment.AddContext("username", userName);
    *
    * Prepare date before running normal run/experiment
    * experiment.BeforeRun(() => ExpensiveSetup());
    *
    * Decide what to store
    * experiment.Clean(user => user.Login);
    *
    * Decide when match/mismatch is
    * experiment.Ignore((control, candidate) => user.IsStaff);
    *
    * Decide when to run an experiment
    * experiment.RunIf(() => user.IsTestSubject);
    */
);
```