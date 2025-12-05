using Day_4___Printing_Department;

namespace AdventOfCode2025.Tests;

public class Day4Tests
{
    private readonly List<string> _testData =
    [
        "..@@.@@@@.",
        "@@@.@.@.@@",
        "@@@@@.@.@@",
        "@.@@@@..@.",
        "@@.@@@@.@@",
        ".@@@@@@@.@",
        ".@.@.@.@@@",
        "@.@@@.@@@@",
        ".@@@@@@@@.",
        "@.@.@@@.@."
    ];

    [Fact]
    public void AccessiblePaperRolls_CorrectOutput()
    {
        // Arrange
        var expectedSum = 13;
        
        // Act
        var result = Day4.AccessiblePaperRolls(_testData);
        
        // Assert
        Assert.Equal(expectedSum, result);
    }

    [Fact]
    public void AccessiblePaperRollsRecursively_CorrectOutput()
    {
        // Arrange
        var expectedSum = 43;
        
        // Act
        var result = Day4.AccessiblePaperRollsRecursively(_testData);
        
        // Assert
        Assert.Equal(expectedSum, result);
    }
    
}