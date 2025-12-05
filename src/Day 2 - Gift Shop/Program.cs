using Day_2___Gift_Shop;

// Advent of Code 2025 - Day 2
// Link: https://adventofcode.com/2025/day/2

Console.WriteLine("Advent of Code 2025 Day 02");
Console.WriteLine("--- Gift Shop ---");

var input = File.ReadAllText("input.txt");
var ranges = Day2.ParseInput(input);

Console.WriteLine("--- Part 1 ---");
var sumOfInvalidIds = Day2.FindInvalidProductIds(ranges);
Console.WriteLine($"The sum of invalid ids is: {sumOfInvalidIds}");

Console.WriteLine("--- Part 2 ---");
var sumOfInvalidProductIds = Day2.FindProductIdWithRepeatingDigits(ranges);
Console.WriteLine($"The sum of invalid product ids is: {sumOfInvalidProductIds}");

Console.ReadLine();