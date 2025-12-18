namespace Day_9___Movie_Theater;

public static class Day9
{
    public record Tile(long X, long Y);
    public static long AreaOfLargestRectangle(List<string> redTilesCoordinates)
    {
        long largestArea = 0;
        
        var tiles = ParseInput(redTilesCoordinates);
        var tilesCount = tiles.Count;
        
        // Defining the corners
        var topLeft = tiles.OrderBy(t => t.X).ThenBy(t => t.Y).Take(tilesCount / 2).ToList();
        var bottomRight = tiles.OrderByDescending(t => t.X).ThenByDescending(t => t.Y).Take(tilesCount / 2).ToList();

        foreach (var tileAsc in topLeft)
        {
            long currentLargestArea = 0;

            foreach (var tileDesc in bottomRight)
            {
                var area = CalculateAreaOfTiles(tileAsc, tileDesc);

                if (area > currentLargestArea)
                {
                    currentLargestArea = area;
                }
            }

            if (currentLargestArea > largestArea)
            {
                largestArea = currentLargestArea;
            }
        }
        
        return largestArea;
    }
    
    public static List<Tile> ParseInput(List<string> input)
    {
        var parsedInput = input
            .Select(t =>
            {
                var coords = t.Split(",");

                var x = long.Parse(coords[0]);
                var y = long.Parse(coords[1]);

                return new Tile(x, y);
            })
            .ToList();
        
        return parsedInput;
    }

    public static long CalculateAreaOfTiles(Tile tile1, Tile tile2)
    {
        var width = Math.Abs(tile1.X - tile2.X) + 1;
        var height = Math.Abs(tile1.Y - tile2.Y) + 1;
        var area = width * height;

        return area;
    }
}