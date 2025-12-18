// Advent of Code 2025 - Day 9
// Link: https://adventofcode.com/2025/day/9


using Day_9___Movie_Theater;

Console.WriteLine("Advent of Code 2025 Day 09");
Console.WriteLine("--- Movie Theater ---");

var input = File.ReadLines("input.txt").ToList();

Console.WriteLine("--- Part 1 ---");
var area = Day9.AreaOfLargestRectangle(input);
Console.WriteLine($"The area of the largest rectangle is: {area}");


Console.ReadLine();