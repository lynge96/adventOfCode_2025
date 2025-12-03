using Day01;

Console.WriteLine("Advent of Code 2025 Day 01");

var input = File.ReadAllText("input.txt");

var numbers = Day1.ParseInput(input);

var firstPassword = Day1.SolveFirstPassword(numbers);
Console.WriteLine($"The password is: '{firstPassword}' for part 1");

var secondPassword = Day1.SolveSecondPassword(numbers);
Console.WriteLine($"The password is: '{secondPassword}' for part 2");

Console.ReadLine();