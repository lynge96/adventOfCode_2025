using Day_3___Lobby;

// Advent of Code 2025 - Day 3
// Link: https://adventofcode.com/2025/day/3

Console.WriteLine("Advent of Code 2025 Day 03");
Console.WriteLine("--- Lobby ---");

var input = File.ReadLines("input.txt").ToList();

Console.WriteLine("--- Part 1 ---");
var totalJoltageForTwoBatteries = Day3.FindMaximumJoltageForTwoBatteries(input);
Console.WriteLine($"The total joltage is: {totalJoltageForTwoBatteries}");

Console.WriteLine("--- Part 2 ---");
var totalJoltageForTwelveBatteries = Day3.FindMaximumJoltageForTwelveBatteries(input);
Console.WriteLine($"The total joltage is: {totalJoltageForTwelveBatteries}");

Console.ReadLine();