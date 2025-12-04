using Day_3___Lobby;

Console.WriteLine("Advent of Code 2025 Day 03");

var input = File.ReadLines("input.txt").ToList();

Console.WriteLine("--- Part 1 ---");
var totalJoltage = Day3.FindMaximumJoltage(input);
Console.WriteLine($"The total joltage is: {totalJoltage}");


Console.ReadLine();