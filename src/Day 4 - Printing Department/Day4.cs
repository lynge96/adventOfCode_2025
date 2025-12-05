namespace Day_4___Printing_Department;

public static class Day4
{
    public static long AccessiblePaperRolls(List<string> paperRolls)
    {
        var paperRollCounter = 0;
        const string paperRollChar = "@";
        const int rollLimit = 4;
 
        List<string[]> arrays = [];
        arrays.AddRange(paperRolls.Select(row => row.Select(c => c.ToString()).ToArray()));
        var amountOfPaperRolls = paperRolls.Count;
        
        for (var roll = 0; roll < amountOfPaperRolls; roll++)
        {
            var rollLen = arrays[roll].Length;

            for (var position = 0; position < rollLen; position++)
            {
                var character = arrays[roll][position];
                
                if (character != paperRollChar)
                {
                    continue;
                }

                var nearbyPaperRolls = 0;
                
                for (var i = -1; i <= 1; i++)
                {
                    if (roll + i < 0 || roll + i >= amountOfPaperRolls)
                    {
                        continue;
                    }

                    for (var j = -1; j <= 1; j++)
                    {
                        if (j == 0 && i == 0 || position + j < 0 || position + j >= rollLen)
                        {
                            continue;
                        }
                        if (arrays[roll + i][position + j].Contains(paperRollChar))
                        {
                            nearbyPaperRolls++;
                        }
                        
                    }
                    
                }
                
                if (nearbyPaperRolls < rollLimit)
                {
                    paperRollCounter++;
                }
                
            }
            
        }
        
        return paperRollCounter;
    }

    public record RollCoordinate(int Row, int Position);
    
    public static long AccessiblePaperRollsRecursively(List<string> paperRolls)
    {
        var paperRollCounter = 0;
        const string paperRollChar = "@";
        const int rollLimit = 4;
 
        List<string[]> arrays = [];
        arrays.AddRange(paperRolls.Select(row => row.Select(c => c.ToString()).ToArray()));
        var amountOfPaperRolls = paperRolls.Count;

        List<RollCoordinate> accessibleRolls = [];
        
        for (var row = 0; row < amountOfPaperRolls; row++)
        {
            var rollLen = arrays[row].Length;

            for (var position = 0; position < rollLen; position++)
            {
                var character = arrays[row][position];
                
                if (character != paperRollChar)
                {
                    continue;
                }

                var nearbyPaperRolls = 0;
                
                for (var i = -1; i <= 1; i++)
                {
                    if (row + i < 0 || row + i >= amountOfPaperRolls)
                    {
                        continue;
                    }

                    for (var j = -1; j <= 1; j++)
                    {
                        if (j == 0 && i == 0 || position + j < 0 || position + j >= rollLen)
                        {
                            continue;
                        }
                        if (arrays[row + i][position + j].Contains(paperRollChar))
                        {
                            nearbyPaperRolls++;
                        }
                        
                    }
                    
                }
                
                if (nearbyPaperRolls < rollLimit)
                {
                    paperRollCounter++;
                    accessibleRolls.Add(new RollCoordinate(row, position));
                }
                
            }
            
        }

        foreach (var roll in accessibleRolls)
        {
            arrays[roll.Row][roll.Position] = "x";
        }
        
        Console.WriteLine($"Iteration: Accessible paper rolls: {paperRollCounter}");

        if (paperRollCounter == 0)
            return 0;

        var updatedPaperRolls = arrays
            .Select(row => string.Concat(row))
            .ToList();
        
        var recursiveCount = AccessiblePaperRollsRecursively(updatedPaperRolls);

        return paperRollCounter + recursiveCount;
    }
}