namespace Day_8___Playground;

public static class Day8
{
    public record JunctionBox(int X, int Y, int Z, int Id);
    public record JunctionConnection(JunctionBox FirstBox, JunctionBox SecondBox, double Length);
    
    public static long SizeOfThreeLargestCircuits(List<string> junctionBoxCoordinates, int pairs)
    {
        // Kruskal's algorithm
        var junctionBoxes = ParseInput(junctionBoxCoordinates);
        var count = junctionBoxes.Count;

        List<JunctionConnection> connections = [];
        
        for (var boxIndex = 0; boxIndex < count - 1; boxIndex++)
        {
            var firstBox = junctionBoxes[boxIndex];

            for (var nextBox = boxIndex + 1; nextBox < count; nextBox++)
            {
                var secondBox = junctionBoxes[nextBox];

                var distance = CalculateDistance(firstBox, secondBox);

                connections.Add(new JunctionConnection(firstBox, secondBox, distance));
            }
            
        }

        var sortedConnections = connections.OrderBy(connection => connection.Length).Take(pairs).ToList();
        
        Dictionary<int, List<int>> circuits = new();
        Dictionary<int, int> boxToCircuit = new();
        
        var circuitCount = 0;
        
        foreach (var connection in sortedConnections)
        {
            var firstBoxId = connection.FirstBox.Id;
            var secondBoxId = connection.SecondBox.Id;

            var firstExists = boxToCircuit.TryGetValue(firstBoxId, out var firstCircuitId);
            var secondExists = boxToCircuit.TryGetValue(secondBoxId, out var secondCircuitId);

            if (!firstExists && !secondExists) // New circuit
            {
                circuits[circuitCount] = new List<int> { firstBoxId, secondBoxId };

                boxToCircuit[firstBoxId] = circuitCount;
                boxToCircuit[secondBoxId] = circuitCount;

                circuitCount++;
                continue;
            }

            if (firstExists && !secondExists) // Add second box to first circuit
            {
                circuits[firstCircuitId].Add(secondBoxId);
                boxToCircuit[secondBoxId] = firstCircuitId;
                continue;
            }
            
            if (!firstExists && secondExists) // Add first box to second circuit
            {
                circuits[secondCircuitId].Add(firstBoxId);
                boxToCircuit[firstBoxId] = secondCircuitId;
                continue;
            }
            
            // Merge circuits
            if (firstCircuitId != secondCircuitId)
            {
                var boxesToMove = circuits[secondCircuitId].ToList();

                foreach (var boxId in boxesToMove)
                {
                    circuits[firstCircuitId].Add(boxId);
                    boxToCircuit[boxId] = firstCircuitId;
                }

                circuits.Remove(secondCircuitId);
            }
        }
        
        var sortedCircuits = circuits
            .OrderByDescending(circuit => circuit.Value.Count)
            .Select(circuit => circuit.Value.Count)
            .Distinct()
            .Take(3)
            .ToList();
        
        var productOfThreeLargestCircuits = sortedCircuits.First();

        for (var i = 1; i < sortedCircuits.Count; i++)
        {
            productOfThreeLargestCircuits *= sortedCircuits[i];
        }
        
        return productOfThreeLargestCircuits;
    }
    
    public static long LastPairInCircuit(List<string> junctionBoxCoordinates)
    {
        // Kruskal's algorithm
        var junctionBoxes = ParseInput(junctionBoxCoordinates);
        var count = junctionBoxes.Count;

        List<JunctionConnection> connections = [];
        
        for (var boxIndex = 0; boxIndex < count - 1; boxIndex++)
        {
            var firstBox = junctionBoxes[boxIndex];

            for (var nextBox = boxIndex + 1; nextBox < count; nextBox++)
            {
                var secondBox = junctionBoxes[nextBox];

                var distance = CalculateDistance(firstBox, secondBox);

                connections.Add(new JunctionConnection(firstBox, secondBox, distance));
            }
            
        }

        var sortedConnections = connections.OrderBy(connection => connection.Length).ToList();
        
        Dictionary<int, List<int>> circuits = new();
        Dictionary<int, int> boxToCircuit = new();
        
        var connCount = sortedConnections.Count;
        var circuitCount = 0;
        var firstXCoordinate = 0;
        var secondXCoordinate = 0;
        
        for (var i = 0; i < connCount; i++)
        {
            var connection = sortedConnections[i];
            var firstBoxId = connection.FirstBox.Id;
            var secondBoxId = connection.SecondBox.Id;

            var firstExists = boxToCircuit.TryGetValue(firstBoxId, out var firstCircuitId);
            var secondExists = boxToCircuit.TryGetValue(secondBoxId, out var secondCircuitId);

            if (!firstExists && !secondExists) // New circuit
            {
                circuits[circuitCount] = new List<int> { firstBoxId, secondBoxId };

                boxToCircuit[firstBoxId] = circuitCount;
                boxToCircuit[secondBoxId] = circuitCount;

                circuitCount++;
                continue;
            }

            if (firstExists && !secondExists) // Add second box to first circuit
            {
                circuits[firstCircuitId].Add(secondBoxId);
                boxToCircuit[secondBoxId] = firstCircuitId;
                continue;
            }
            
            if (!firstExists && secondExists) // Add first box to second circuit
            {
                circuits[secondCircuitId].Add(firstBoxId);
                boxToCircuit[firstBoxId] = secondCircuitId;
                continue;
            }
            
            // Merge circuits
            if (firstCircuitId != secondCircuitId)         
            {
                var boxesToMove = circuits[secondCircuitId].ToList();

                foreach (var boxId in boxesToMove)
                {
                    circuits[firstCircuitId].Add(boxId);
                    boxToCircuit[boxId] = firstCircuitId;
                }

                circuits.Remove(secondCircuitId);
            }
            
            if (circuits.Count == 1 && boxToCircuit.Count == count)
            {
                var previousConn = sortedConnections[i-1];

                firstXCoordinate = previousConn.FirstBox.X;
                secondXCoordinate = previousConn.SecondBox.X;
                break;
            }
        }
        
        var productOfXCoordinates = firstXCoordinate * secondXCoordinate;
        
        return productOfXCoordinates;
    }
    
    public static List<JunctionBox> ParseInput(List<string> input)
    {
        List<JunctionBox> junctionBoxes = [];
        var id = 1;
        
        foreach (var box in input)
        {
            var coordinates = box.Split(",");

            var junctionBox = new JunctionBox(
                int.Parse(coordinates[0]),
                int.Parse(coordinates[1]),
                int.Parse(coordinates[2]),
                id);
            
            junctionBoxes.Add(junctionBox);
            
            id++;
        }
        
        return junctionBoxes;
    }

    public static double CalculateDistance(JunctionBox box1, JunctionBox box2)
    {
        // Euclidean distance
        long dx = Math.Abs(box1.X - box2.X);
        long dy = Math.Abs(box1.Y - box2.Y);
        long dz = Math.Abs(box1.Z - box2.Z);

        var distance =Math.Sqrt(dx * dx + dy * dy + dz * dz);
        
        return distance;
    }
    
}