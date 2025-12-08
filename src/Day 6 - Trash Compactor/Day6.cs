using System.Text.RegularExpressions;

namespace Day_6___Trash_Compactor;

public static class Day6
{
    public record MathProblem(List<int> Numbers, string Operator);

    public static List<MathProblem> ParseInput(List<string> input)
    {
        List<MathProblem> problems = [];
        
        var worksheet = input.Select(l => l.Split(" ", StringSplitOptions.RemoveEmptyEntries)).ToList();

        for (var column = 0; column < worksheet[0].Length; column++)
        {
            List<int> numbers = [];
            var operatorString = "";
            
            for (var row = 0; row < worksheet.Capacity; row++)
            {
                if (row == worksheet.Capacity - 1)
                {
                    operatorString = worksheet[row][column];
                    continue;
                }
                
                numbers.Add(worksheet[row].Select(int.Parse).ToList()[column]);
            }
            
            problems.Add(new MathProblem(numbers, operatorString));
        }
        
        return problems;
    }
    
    public static long GrandTotalOfProblems(List<MathProblem> problems)
    {
        long sumOfProblems = 0;

        foreach (var problem in problems)
        {
            long sum = problem.Numbers.First();

            for (var i = 1; i < problem.Numbers.Count; i++)
            {
                switch (problem.Operator)
                {
                    case "*":
                        sum *= problem.Numbers[i];
                        continue;
                    case "+":
                        sum += problem.Numbers[i];
                        continue;
                }
            }
            
            sumOfProblems += sum;
            
            var expression = string.Join($" {problem.Operator} ", problem.Numbers);
            var fullExpression = $"{expression} = {sum}";
            Console.WriteLine(fullExpression);
        }
        
        return sumOfProblems;
    }

    public record CehalopodMathProblem(List<string> Numbers, string Operator);
    
    public static List<CehalopodMathProblem> CephalopodParseInput(List<string> input)
    {
        List<CehalopodMathProblem> problems = [];

        var operatorLine = input.Last();
        var numberLines = input.Take(input.Count - 1).ToList();
        
        var opToken = new Regex(@"[+\-*]\s*");
        
        var currentOperator = operatorLine.Substring(0, 1);
        var boundary = 0;
        
        for (var i = 1; i < operatorLine.Length; i++)
        {
            List<string> numberStrings = [];
            var op = "";
            
            if (i != operatorLine.Length - 1)
            {
                op = operatorLine.Substring(i, 1);
            }

            if (i == operatorLine.Length - 1)
            {
                numberStrings.AddRange(numberLines.Select(numbers => numbers[boundary..]));
                problems.Add(new CehalopodMathProblem(numberStrings, currentOperator));

                continue;
            }
            
            if (opToken.IsMatch(op))
            {
                numberStrings.AddRange(numberLines.Select(numbers => numbers
                    .Substring(boundary, i - boundary - 1)));
                problems.Add(new CehalopodMathProblem(numberStrings, currentOperator));
                
                boundary = i;
                currentOperator = op;
            }
        }
        
        return problems;
    }
    
    public static long SolveCephalopodMathProblems(List<CehalopodMathProblem> problems)
    {
        long sumOfProblems = 0;

        foreach (var problem in problems)
        {
            var expression = string.Join($"\n", problem.Numbers);

            Console.WriteLine($"{expression}");
            Console.WriteLine(problem.Operator);
            long sumOfProblem = 0;

            var len = problem.Numbers.First().Length;

            for (var i = len; i > 0; i--)
            {
                var numbers = problem.Numbers
                    .Select(n => n.Substring(i - 1, 1))
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .ToList();

                var aggregatedNumber = long.Parse(numbers.Aggregate("", (current, number) => current + number));
                
                switch (problem.Operator)
                {
                    case "*":
                        sumOfProblem = sumOfProblem == 0 ? aggregatedNumber : sumOfProblem * aggregatedNumber;
                        continue;
                    case "+":
                        sumOfProblem += aggregatedNumber;
                        continue;
                }
            }
            
            Console.WriteLine($"Sum of problem: {sumOfProblem}\n");
            sumOfProblems += sumOfProblem;
        }
        
        return sumOfProblems;
    }
}