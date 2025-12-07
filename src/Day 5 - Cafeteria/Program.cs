// Advent of Code 2025 - Day 5
// Link: https://adventofcode.com/2025/day/5

using Day_5___Cafeteria;

Console.WriteLine("Advent of Code 2025 Day 05");
Console.WriteLine("--- Cafeteria ---");

var input = File.ReadLines("input.txt").ToList();

Console.WriteLine("--- Part 1 ---");
var countIngredients = Day5.CountAvailableIngredients(input);
Console.WriteLine($"The number of available ingredients is: {countIngredients}");

Console.WriteLine("--- Part 2 ---");
var totalAvailableIngredients = Day5.TotalAvailableIngredients(input);
Console.WriteLine($"The total number of available ingredients is: {totalAvailableIngredients}");


Console.ReadLine();