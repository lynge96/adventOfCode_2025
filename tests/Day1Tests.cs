using Day01;

namespace AdventOfCode2025.Tests;

public class Day1Tests
{
    [Fact]
    public void ParseInput_ReturnsExpectedInts()
    {
        // Arrange
        var input = "R21\nR37\nL39";
        var expected = new[] { 21, 37, -39 };
        
        // Act
        var result = Day1.ParseInput(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SolveFirstPassword_ReturnsExpectedPassword()
    {
        // Arrange
        var input = new[] { 50, 37, -39, 2 };
        var expected = 2;
        
        // Act
        var result = Day1.SolveFirstPassword(input);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SolveSecondPassword_ReturnsExpectedPassword()
    {
        // Arrange
        var input = new[] { -68, -30, 48, -5, 60, -55, -1, -99, 14, -82 };
        var expected = 6;
        
        // Act
        var result = Day1.SolveSecondPassword(input);
        
        // Assert
        Assert.Equal(expected, result);
    }
}