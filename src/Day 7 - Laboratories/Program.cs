// Advent of Code 2025 - Day 7
// Link: https://adventofcode.com/2025/day/7

using Day_7___Laboratories;

Console.WriteLine("Advent of Code 2025 Day 07");
Console.WriteLine("--- Laboratories ---");

var input = File.ReadLines("input.txt").ToList();

Console.WriteLine("--- Part 1 ---");
var splitCounter = Day7.CountBeamSplitting(input);
Console.WriteLine($"The number of times the beam is split: {splitCounter}");

Console.WriteLine("--- Part 2 ---");
var timelines = Day7.NumberOfTimelines(input);
Console.WriteLine($"The number of timelines: {timelines}");

Console.ReadLine();