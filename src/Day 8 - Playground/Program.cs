// Advent of Code 2025 - Day 8
// Link: https://adventofcode.com/2025/day/8

using Day_8___Playground;

Console.WriteLine("Advent of Code 2025 Day 08");
Console.WriteLine("--- Playground ---");

var input = File.ReadLines("input.txt").ToList();

Console.WriteLine("--- Part 1 ---");
var size = Day8.SizeOfThreeLargestCircuits(input);
Console.WriteLine($"The size of the three largest circuits is: {size}");

Console.ReadLine();