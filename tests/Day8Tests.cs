using Day_8___Playground;

namespace AdventOfCode2025.Tests;

public class Day8Tests
{
    private readonly List<string> _testJunctionBoxes =
    [
        "162,817,812",
        "57,618,57",
        "906,360,560",
        "592,479,940",
        "352,342,300",
        "466,668,158",
        "542,29,236",
        "431,825,988",
        "739,650,466",
        "52,470,668",
        "216,146,977",
        "819,987,18",
        "117,168,530",
        "805,96,715",
        "346,949,466",
        "970,615,88",
        "941,993,340",
        "862,61,35",
        "984,92,344",
        "425,690,689"
    ];

    [Fact]
    public void SizeOfThreeLargestCircuits_CorrectSizeOutput()
    {
        // Arrange
        var expectedSize = 40;
        
        // Act
        var pairs = 10;
        var result = Day8.SizeOfThreeLargestCircuits(_testJunctionBoxes, pairs);
        
        // Assert
        Assert.Equal(expectedSize, result);
    }

    [Fact]
    public void LastPairInCircuit_CorrectOutput()
    {
        // Arrange
        var expectedProduct = 25272;
        
        // Act
        var result = Day8.LastPairInCircuit(_testJunctionBoxes);
        
        // Assert
        Assert.Equal(expectedProduct, result);
    }
}