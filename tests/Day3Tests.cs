using Day_3___Lobby;

namespace AdventOfCode2025.Tests;

public class Day3Tests
{
    private readonly List<string> _testData =
    [
        "987654321111111",
        "811111111111119",
        "234234234234278",
        "818181911112111"
    ];

    [Fact]
    public void FindMaximumJoltage_CorrectMaximumOutput()
    {
        // Arrange
        var expectedSum = 357;
        
        // Act
        var result = Day3.FindMaximumJoltage(_testData);
        
        // Assert
        Assert.Equal(expectedSum, result);
    }

    [Theory]
    [InlineData("987654321111111", 98)]
    [InlineData("811111111111119", 89)]
    [InlineData("234234234234278", 78)]
    [InlineData("818181911112111", 92)]
    public void BankJoltage_CorrectOutput(string batteryBank, int expectedJoltage)
    {
        // Act
        var result = Day3.BankJoltage(batteryBank);
        
        // Assert
        Assert.Equal(expectedJoltage, result);
    }
    
}