namespace Day_2___Gift_Shop;

public static class Day2
{
    public record Range(long Start, long End);

    public static List<Range> ParseInput(string input)
    {
        var ranges = input
            .Split(",", StringSplitOptions.TrimEntries)
            .Select(r =>
            {
                var parts = r.Split("-");
                
                var start = long.Parse(parts[0]);
                var end = long.Parse(parts[1]);
                
                // Console.WriteLine($"{start} - {end}");
                return new Range(start, end);
            })
            .ToList();
               
        return ranges;
    }

    public static long FindInvalidProductIds(List<Range> ranges)
    {
        long sumOfInvalidIds = 0;
            
        foreach (var range in ranges)
        {
            Console.WriteLine($"\nChecking range: {range.Start} - {range.End}");
            
            for (var productId = range.Start; productId <= range.End; productId++)
            {
                var id = productId.ToString();
                var idLen = id.Length;
                
                if(idLen % 2 != 0 || idLen == 0)
                    continue;

                var (firstHalf, secondHalf) = SplitNumber(productId);

                if (firstHalf.Equals(secondHalf))
                {
                    Console.WriteLine($"> Invalid product id: {productId}");
                    sumOfInvalidIds += productId;
                }
            }
        }

        return sumOfInvalidIds;
    }
    
    public static (long firstNumber, long secondNumber) SplitNumber(long number)
    {
        var s = number.ToString();
        var len = s.Length;
        
        var firstStr = s.Substring(0, len / 2);
        var secondStr = s.Substring(len / 2);

        var firstHalfNumber = long.Parse(firstStr);
        var secondHalfNumber = long.Parse(secondStr);
        
        return (firstHalfNumber, secondHalfNumber);
    }
    
    public static long FindProductIdWithRepeatingDigits(List<Range> ranges)
    {
        long sumOfInvalidIds = 0;

        foreach (var range in ranges)
        {
            var invalidIdCounter = 0;
            var invalidIds = new List<long>();
            Console.WriteLine($"\nChecking range: {range.Start} - {range.End}");
            
            for (var productId = range.Start; productId <= range.End; productId++)
            {
                var id = productId.ToString();
                var idLen = id.Length;
                
                var divider = 2;

                while (divider <= idLen)
                {
                    if (idLen % divider == 0)
                    {
                        var idHasRepeatingDigits = CheckNumberSequences(id, divider);

                        if (idHasRepeatingDigits)
                        {
                            invalidIds.Add(productId);
                            invalidIdCounter++;
                            
                            sumOfInvalidIds += productId;
                            break;
                        }
                    }
                    
                    divider++;
                }
            }
            Console.WriteLine($"{invalidIdCounter} invalid product ids in range: {string.Join(", ", invalidIds)}");
        }
        
        return sumOfInvalidIds;
    }

    public static bool CheckNumberSequences(string productId, int partsToSplit)
    {
        var partLen = productId.Length / partsToSplit;
        
        var firstPart = productId.Substring(0, partLen);
        
        for (var i = 1; i < partsToSplit; i++)
        {
            var nextPart = productId.Substring(i * partLen, partLen);
            if (!string.Equals(firstPart, nextPart))
                return false;
        }
        
        return true;
    }
    
}