using System.Text.RegularExpressions;

namespace Day_7___Laboratories;

public static class Day7
{
    public static int CountBeamSplitting(List<string> manifold)
    {
        var splitCount = 0;
        
        var startSymbol = new Regex("S");
        var splitSymbol = new Regex(@"\^");
        
        List<int> tachyonBeams = [startSymbol.Match(manifold[0]).Index]; // Start index of beam, starts under S

        for (var i = 1; i < manifold.Count; i++)
        {
            List<int> newIndices = [];
            List<int> oldIndices = [];
            var line = manifold[i];
            
            foreach (var beamIndex in tachyonBeams) // 8
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
}