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
}