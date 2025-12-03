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
                var idLength = id.Length;
                
                if(idLength % 2 != 0 || idLength == 0)
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
    
}