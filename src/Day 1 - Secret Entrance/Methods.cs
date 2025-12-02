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
    
    public static int SolveFirstPassword(int[] input)
    {
        var dialSize = 50;
        var zeroPassCounter = 0;

        foreach (var i in input)
        {
            var newPosition = (dialSize + i) % 100;

            if (newPosition == 0)
            {
                zeroPassCounter ++;
            }

            dialSize = newPosition;
        }

        return zeroPassCounter ;
    }

    public static int SolveSecondPassword(int[] input)
    {
        const int dialSize = 100;
        var dial = 50;
        var zeroPassCounter = 0;

        foreach (var rotation  in input)
        {
            if (rotation > 0)
            {
                var clicksToFirstZero = (dialSize - dial) % dialSize;
                
                if (clicksToFirstZero == 0)
                    clicksToFirstZero = dialSize;

                if (rotation >= clicksToFirstZero)
                {
                    zeroPassCounter += 1 + (rotation - clicksToFirstZero) / dialSize;
                }
            }
            else if (rotation < 0)
            {
                var leftClicks = Math.Abs(rotation);

                var clicksToFirstZero = dial;
                
                if (clicksToFirstZero == 0)
                    clicksToFirstZero = dialSize;

                if (leftClicks >= clicksToFirstZero)
                {
                    zeroPassCounter += 1 + (leftClicks - clicksToFirstZero) / dialSize;
                }
            }
            
            dial = NormalizePosition(dial + rotation, dialSize);        }
        
        return zeroPassCounter;
    }
    

    private static int NormalizePosition(int value, int modulo)
    {
        var result = value % modulo;
        
        if (result < 0)
            result += modulo;

        return result;
    }
}