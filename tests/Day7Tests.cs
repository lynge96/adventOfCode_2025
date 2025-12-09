using Day_7___Laboratories;

namespace AdventOfCode2025.Tests;

public class Day7Tests
{
    private readonly List<string> _testManifold =
    [
        ".......S.......",
        "...............",
        ".......^.......",
        "...............",
        "......^.^......",
        "...............",
        ".....^.^.^.....",
        "...............",
        "....^.^...^....",
        "...............",
        "...^.^...^.^...",
        "...............",
        "..^...^.....^..",
        "...............",
        ".^.^.^.^.^...^.",
        "..............."
    ];
    
    [Fact]
    public void CountBeamSplitting_CorrectOutput()
    {
        // Arrange
        var expectedSum = 21;
        
        // Act
        var result = Day7.CountBeamSplitting(_testManifold);
        
        // Assert
        Assert.Equal(expectedSum, result);
    }

}