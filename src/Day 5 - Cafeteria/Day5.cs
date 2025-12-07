namespace Day_5___Cafeteria;

public static class Day5
{
    public record ProductId(long Id);
    public record Ranges(long Start, long End);

    public static (List<Ranges>, List<ProductId>) ParseInput(List<string> input)
    {
        List<Ranges> ingredientIdRanges = [];
        List<ProductId> availableIngredientIds = [];

        foreach (var line in input)
        {
            if (line.Contains('-'))
            {
                var range = line.Split('-');
                ingredientIdRanges.Add(new Ranges(long.Parse(range[0]), long.Parse(range[1])));
            }
            else if (long.TryParse(line, out var id))
            {
                availableIngredientIds.Add(new ProductId(id));
            }
        }
        
        return (ingredientIdRanges, availableIngredientIds);
    }

    public static long CountAvailableIngredients(List<string> input)
    {
        var (ingredientIdRanges, availableIngredientIds) = ParseInput(input);
        
        var freshIngredientCount = 0;
        
        foreach (var ingredientId in availableIngredientIds)
        {
            if (ingredientIdRanges.Any(range => ingredientId.Id >= range.Start && ingredientId.Id <= range.End))
            {
                Console.WriteLine($"Found fresh ingredient: {ingredientId.Id}");
                freshIngredientCount++;
            }
        }
        
        return freshIngredientCount;
    }
    
    public static long TotalAvailableIngredients(List<string> input)
    {
        var (ingredientIdRanges, _) = ParseInput(input);
        
        var sortedRanges = SortAndMergeRanges(ingredientIdRanges);

        return sortedRanges.Sum(ingredientIdRange => ingredientIdRange.End - ingredientIdRange.Start + 1);
    }
    
    public static List<Ranges> SortAndMergeRanges(List<Ranges> ranges)
    {
        var sorted = ranges
            .OrderBy(r => r.Start)
            .ThenBy(r => r.End)
            .ToList();

        List<Ranges> result = [];

        var currentStart = sorted[0].Start;
        var currentEnd = sorted[0].End;

        foreach (var range in sorted.Skip(1))
        {
            var threshold = currentEnd + 1;

            if (range.Start <= threshold)
            {
                currentEnd = Math.Max(currentEnd, range.End);
            }
            else
            {
                result.Add(new Ranges(currentStart, currentEnd));
                currentStart = range.Start;
                currentEnd = range.End;
            }
        }
        
        result.Add(new Ranges(currentStart, currentEnd));
        return result;
    }
    
}