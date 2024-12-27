# 094 - What Week Is Today? #

This silly question might not be that silly if you are in a country that relies on week numbers.
To answer this question using C# we can use `GetWeekOfYear` method that's available on `Calendar` class.

However, this method introduces some complexity. Apart from passing the date, it requires two additional parameters: `CalendarWeekRule` and `DayOfWeek`.

* `CalendarWeekRule` controls when the first week of the year starts and can take one of the following values:
    * `FirstDay`
    * `FirstFullWeek`
    * `FirstFourDayWeek`

* `DayOfWeek` determines the first day of the week and can range from `Monday` to `Sunday`.

Here's an example to determine the week number for the last day of 2025:

```csharp
var date = DateTime.Parse("2025-12-31", CultureInfo.InvariantCulture);
var weekNo =
    CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
Console.WriteLine($"Week no for {date:d} with {CalendarWeekRule.FirstFourDayWeek}, {DayOfWeek.Monday} is {weekNo}");
// Week no for 31.12.2025 with FirstFourDayWeek, Monday is 53
```

but if we would change `FirstFourDayWeek` to `FirstFullWeek` we would get a different result.

```csharp
var weekNo =
    CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
Console.WriteLine($"Week no for {date:d} with {CalendarWeekRule.FirstFullWeek}, {DayOfWeek.Monday} is {weekNo}");
// Week no for 31.12.2025 with FirstFullWeek, Monday is 52
```

In this example, the value `CalendarWeekRule.FirstDay` would give the same output as `CalendarWeekRule.FirstFourDayWeek`, but this might not always be the case.

But that's not all-there's also the `ISOWeek` class, which follows ISO rules for week number calculations. The results from `ISOWeek` may differ from those of the `Calendar` class.

```csharp
Console.WriteLine($"ISO week for {date:d} is {ISOWeek.GetWeekOfYear(date)}");
// ISO week for 31.12.2025 is 1
```

So, the next time someone asks you to calculate a week number, be sure to ask them how they want it to be determined.