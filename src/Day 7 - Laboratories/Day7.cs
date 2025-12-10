using System.Text.RegularExpressions;

namespace Day_7___Laboratories;

public static partial class Day7
{
    [GeneratedRegex("S")]
    private static partial Regex Start();
    [GeneratedRegex(@"\^")]
    private static partial Regex Splitter();
    
    public static int CountBeamSplitting(List<string> manifold)
    {
        var splitCount = 0;
        
        var startSymbol = Start();
        var splitSymbol = Splitter();
        
        List<int> tachyonBeams = [startSymbol.Match(manifold[0]).Index]; // Start index of beam, starts under S

        for (var i = 1; i < manifold.Count; i++)
        {
            List<int> newIndices = [];
            List<int> oldIndices = [];
            var line = manifold[i];
            
            foreach (var beamIndex in tachyonBeams)
            {
                var character = manifold[i].Substring(beamIndex, 1);
                
                if (splitSymbol.IsMatch(character))
                {
                    if (beamIndex + 1 < line.Length)
                        newIndices.Add(beamIndex + 1);
                    if (beamIndex - 1 >= 0)
                        newIndices.Add(beamIndex - 1);

                    oldIndices.Add(beamIndex);
                    splitCount++;
                }
                
            }

            tachyonBeams.RemoveAll(x => oldIndices.Contains(x));
            tachyonBeams.AddRange(newIndices.Where(x => !tachyonBeams.Contains(x)));

            foreach (var beam in tachyonBeams)
            {
                line = line.Substring(0, beam) + "|" + line.Substring(beam + 1);
            }
            
            manifold[i] = line;
        }
        
        Console.WriteLine(string.Join("\n", manifold));
        return splitCount;
    }
    
    // Top-down with memoization
    public static long NumberOfTimelines(List<string> manifold)
    {
        var grid = ConvertToGrid(manifold);
        var rows = manifold.Count;

        var startIndex = Start().Match(manifold[0]).Index;

        var memo = new Dictionary<(int, int), long>();

        return CountFrom(1, startIndex);

        long CountFrom(int row, int col)
        {
            if (row == rows - 1) return 1;

            var key = (row, col);
            if (memo.TryGetValue(key, out var cached)) 
                return cached;

            long result;
            
            var character = grid[row, col];
            if (character == '^')
            {
                result = CountFrom(row + 1, col - 1) + CountFrom(row + 1, col + 1);
            }
            else
            {
                result = CountFrom(row + 1, col);
            }

            memo[key] = result;
            return result;
        }
    }
    
    private static char[,] ConvertToGrid(List<string> manifold)
    {
        int rows = manifold.Count;
        int cols = manifold[0].Length;
        char[,] grid2D = new char[rows, cols];

        for (var r = 0; r < rows; r++)
        {
            for (var c = 0; c < cols; c++)
            {
                grid2D[r, c] = manifold[r][c];
            }
        }
        
        return grid2D;
    }
    
}