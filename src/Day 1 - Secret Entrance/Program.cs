using Day01;

Console.WriteLine("Advent of Code 2025 Day 01");

var input = File.ReadAllText("input.txt");

var numbers = Methods.ParseInput(input);

var firstPassword = Methods.SolveFirstPassword(numbers);
Console.WriteLine($"The password is: '{firstPassword}' for part 1");

var secondPassword = Methods.SolveSecondPassword(numbers);
Console.WriteLine($"The password is: '{secondPassword}' for part 2");

Console.ReadLine();