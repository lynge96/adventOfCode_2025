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
}