DayOfWeek[] days =
[
    DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday,
    DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday
];

// using Random.Shared to access shared instance + shuffle to reorganize elements
Random.Shared.Shuffle(days);
Array.ForEach(days, day => Console.WriteLine($"Day: {day}"));

Console.WriteLine("Pick 3:");
// GetItems will pick k elements
Array.ForEach(Random.Shared.GetItems(days, 3), day => Console.WriteLine($"Day: {day}"));

// ❗ Note: it might generate duplicates