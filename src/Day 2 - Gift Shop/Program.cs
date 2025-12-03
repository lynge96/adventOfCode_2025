using Day_2___Gift_Shop;

Console.WriteLine("Advent of Code 2025 Day 02");

var input = File.ReadAllText("input.txt");

var ranges = Day2.ParseInput(input);

var sumOfInvalidIds = Day2.FindInvalidProductIds(ranges);
Console.WriteLine($"The sum of invalid ids is: {sumOfInvalidIds}");

Console.ReadLine();