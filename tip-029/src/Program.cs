// See https://aka.ms/new-console-template for more information

int[] fib = [1, 1, 2, 3, 5, 8, 13, 21, 34, 55];

Console.WriteLine(fib[^1]);
Console.WriteLine("---");
Array.ForEach(fib[..^1], Console.WriteLine);
Console.WriteLine("---");
Array.ForEach(fib[6..], Console.WriteLine);