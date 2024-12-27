using System.Globalization;

Console.WriteLine("Tip-094 demo");
// More tips: https://github.com/pawlos/dotnet-daily-tips

var date = DateTime.Parse("2025-12-31", CultureInfo.InvariantCulture);
var weekNo =
    CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
Console.WriteLine($"Week no for {date:d} with {CalendarWeekRule.FirstFourDayWeek}, {DayOfWeek.Monday} is {weekNo}");
weekNo =
    CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
Console.WriteLine($"Week no for {date:d} with {CalendarWeekRule.FirstFullWeek}, {DayOfWeek.Monday} is {weekNo}");
weekNo =
    CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
Console.WriteLine($"Week no for {date:d} with {CalendarWeekRule.FirstDay}, {DayOfWeek.Monday} is {weekNo}");
Console.WriteLine($"ISO week for {date:d} is {ISOWeek.GetWeekOfYear(date)}");