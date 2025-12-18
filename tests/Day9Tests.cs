using Day_9___Movie_Theater;

namespace AdventOfCode2025.Tests;

public class Day9Tests
{
    private readonly List<string> _testTiles =
    [
        "2,5", "9,7", "7,1", "11,7", "7,3", "2,3", "2,5", "11,1"
    ];
    
    [Fact]
    public void AreaOfLargestRectangle_CorrectArea()
    {
        // Arrange
        var expectedArea = 50;
        
        // Act
        var result = Day9.AreaOfLargestRectangle(_testTiles);
        
        // Assert
        Assert.Equal(expectedArea, result);
    }
    
    
}