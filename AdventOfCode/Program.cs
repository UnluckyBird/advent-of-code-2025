using AdventOfCode.Days;
using System.Diagnostics;

long startTime = Stopwatch.GetTimestamp();
Console.WriteLine("********************************************************");
Console.WriteLine("** ADVENT OF CODE 2025 BY MARTIN DE FRIES JUSTINUSSEN **");
Console.WriteLine("********************************************************");
//Day 1
Console.WriteLine("Day 1.1: " + Day1.Part1());
Console.WriteLine("Day 1.2: " + Day1.Part2());
Console.WriteLine($"Day 1 Execution Time: {Stopwatch.GetElapsedTime(startTime).TotalMilliseconds} ms");
Console.WriteLine($"Total Execution Time: {Stopwatch.GetElapsedTime(startTime).TotalMilliseconds} ms");

//Day 2
Console.WriteLine("Day 2.1: " + Day2.Part1());
Console.WriteLine("Day 2.2: " + Day2.Part2());
Console.WriteLine($"Day 2 Execution Time: {Stopwatch.GetElapsedTime(startTime).TotalMilliseconds} ms");
Console.WriteLine($"Total Execution Time: {Stopwatch.GetElapsedTime(startTime).TotalMilliseconds} ms");

Console.ReadKey();