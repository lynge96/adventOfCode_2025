using System.Runtime.InteropServices;

namespace Day_8___Playground;

public static class Day8
{
    public record JunctionBox(int X, int Y, int Z);
    public record JunctionPair(JunctionBox Box1, JunctionBox Box2, double Distance);

    public record Circuit(List<JunctionBox> Boxes);
    
    public static long SizeOfThreeLargestCircuits(List<string> junctionBoxCoordinates)
    {
        var sum = 0;
        
        var junctionBoxes = ParseInput(junctionBoxCoordinates);
        var count = junctionBoxes.Count;

        List<JunctionPair> pairs = [];

        for (var boxIndex = 0; boxIndex < count; boxIndex++)
        {
            JunctionBox currentBox = junctionBoxes[boxIndex];
            var (closestBox, distance) = FindClosestJunctionBox(junctionBoxes, currentBox);

            pairs.Add(new JunctionPair(currentBox, closestBox, distance));
        }
        
        var shortestDistances = pairs.OrderBy(pair => pair.Distance).ToList();
        var first = shortestDistances.First();

        List<JunctionBox> firstCircuit = [first.Box1, first.Box2];
        
        List<Circuit> circuits = [new(firstCircuit)];
        
        foreach (var junctionPair in shortestDistances)
        {
            JunctionBox box1 = junctionPair.Box1;
            JunctionBox box2 = junctionPair.Box2;

            // Check om box2's tættest box er box1, ellers så fortsæt og lav et circuit ud af dem alle.
            
        }

        return sum;
    }

    public static (JunctionBox, double distance) FindClosestJunctionBox(List<JunctionBox> junctionBoxes, JunctionBox box)
    {
        JunctionBox? closestBox = null;
        double shortestDistance = double.MaxValue;

        foreach (var junctionBox in junctionBoxes)
        {
            if (junctionBox == box)
                continue;
            
            var distance = CalculateDistance(box, junctionBox);
                
            if (distance <= shortestDistance)
            {
                shortestDistance = distance;
                closestBox = junctionBox;
            }
        }
        
        return (closestBox!, shortestDistance);
    }
    
    public static List<JunctionBox> ParseInput(List<string> input)
    {
        List<JunctionBox> junctionBoxes = [];

        foreach (var box in input)
        {
            var coordinates = box.Split(",");

            var junctionBox = new JunctionBox(
                int.Parse(coordinates[0]),
                int.Parse(coordinates[1]),
                int.Parse(coordinates[2]));
            
            junctionBoxes.Add(junctionBox);
        }
        
        return junctionBoxes;
    }

    public static double CalculateDistance(JunctionBox box1, JunctionBox box2)
    {
        // Euclidean distance
        var dx = box1.X - box2.X;
        var dy = box1.Y - box2.Y;
        var dz = box1.Z - box2.Z;

        return Math.Sqrt(dx * dx + dy * dy + dz * dz);
    }
    
}