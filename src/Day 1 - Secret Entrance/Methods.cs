namespace Day01;

public static class Methods
{
    public static int[] ParseInput(string input)
    {
        return input
            .Replace("L", "-")
            .Replace("R", "")
            .Split(['\n', '\r'], StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }
    
    public static int SolvePassword(int[] input)
    {
        var dial = 50;
        var counter = 0;

        foreach (var i in input)
        {
            var newPosition = (dial + i) % 100;

            if (newPosition == 0)
            {
                counter++;
            }

            dial = newPosition;
        }

        return counter;
    }
}