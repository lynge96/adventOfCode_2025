using Day01;

// Advent of Code 2025 - Day 1
// Link: https://adventofcode.com/2025/day/1

Console.WriteLine("Advent of Code 2025 Day 01");
Console.WriteLine("--- Secret Entrance ---");

var input = File.ReadAllText("input.txt");

var numbers = Day1.ParseInput(input);

Console.WriteLine("--- Part 1 ---");
var firstPassword = Day1.SolveFirstPassword(numbers);
Console.WriteLine($"The password is: '{firstPassword}' for part 1");

Console.WriteLine("--- Part 2 ---");
var secondPassword = Day1.SolveSecondPassword(numbers);
Console.WriteLine($"The password is: '{secondPassword}' for part 2");

Console.ReadLine();