using Day01;

Console.WriteLine("Advent of Code 2025 Day 01");

var input = File.ReadAllText("input.txt");

var numbers = Methods.ParseInput(input);

var password = Methods.SolvePassword(numbers);

Console.WriteLine($"The password is: {password}");
Console.ReadLine();