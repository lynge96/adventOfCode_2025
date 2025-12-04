using Day_3___Lobby;

Console.WriteLine("Advent of Code 2025 Day 03");

var input = File.ReadLines("input.txt").ToList();

Console.WriteLine("--- Part 1 ---");
var totalJoltageForTwoBatteries = Day3.FindMaximumJoltageForTwoBatteries(input);
Console.WriteLine($"The total joltage is: {totalJoltageForTwoBatteries}");

Console.WriteLine("--- Part 2 ---");
var totalJoltageForTwelveBatteries = Day3.FindMaximumJoltageForTwelveBatteries(input);
Console.WriteLine($"The total joltage is: {totalJoltageForTwelveBatteries}");

Console.ReadLine();