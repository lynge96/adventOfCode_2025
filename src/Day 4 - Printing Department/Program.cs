
// Advent of Code 2025 - Day 4
// Link: https://adventofcode.com/2025/day/4

using Day_4___Printing_Department;

Console.WriteLine("Advent of Code 2025 Day 04");
Console.WriteLine("--- Printing Department ---");

var input = File.ReadLines("input.txt").ToList();

Console.WriteLine("--- Part 1 ---");
var paperRolls = Day4.AccessiblePaperRolls(input);
Console.WriteLine($"The number of accessible paper rolls is: {paperRolls}");

Console.WriteLine("--- Part 2 ---");
var paperRollsRecursively = Day4.AccessiblePaperRollsRecursively(input);
Console.WriteLine($"The number of accessible paper rolls recursively is: {paperRollsRecursively}");

Console.ReadLine();