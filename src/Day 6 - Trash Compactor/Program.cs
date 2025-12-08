// Advent of Code 2025 - Day 6
// Link: https://adventofcode.com/2025/day/6

using Day_6___Trash_Compactor;

Console.WriteLine("Advent of Code 2025 Day 06");
Console.WriteLine("--- Trash Compactor ---");

var input = File.ReadLines("input.txt").ToList();

var parsedInput = Day6.ParseInput(input);

Console.WriteLine("--- Part 1 ---");
var grandTotal = Day6.GrandTotalOfProblems(parsedInput);
Console.WriteLine($"The grand total is: {grandTotal}");

Console.WriteLine("--- Part 2 ---");
var cephalopodParsedInput = Day6.CephalopodParseInput(input);
var cephalopodMathGrandTotal = Day6.SolveCephalopodMathProblems(cephalopodParsedInput);
Console.WriteLine($"The grand total is: {cephalopodMathGrandTotal}");

Console.ReadLine();